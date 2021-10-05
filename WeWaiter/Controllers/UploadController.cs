using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WeWaiter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly ILogger<UploadController> _logger;

        public UploadController(IWebHostEnvironment hostEnvironment, ILogger<UploadController> logger)
        {
            _hostEnvironment = hostEnvironment;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Post([Required] IFormFile file, string fileKey = "")
        {
            var domain = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}";
            var filename = string.IsNullOrEmpty(fileKey) ? $"files/{Guid.NewGuid():N}{Path.GetExtension(file.FileName)}" : $"{(fileKey.StartsWith("/") ? fileKey[1..] : fileKey)}";
            var path = Path.Join(_hostEnvironment.WebRootPath, "/uploads".Trim('/', '\\'), filename);

            try
            {
                await SaveFile(file, path);
                var relative = path.Substring(_hostEnvironment.WebRootPath.Length).Replace("\\", "/");
                var data = new
                {
                    type = file.ContentType,
                    size = file.Length,
                    path = domain + relative,
                    url = relative
                };
                return Ok(new { code = 1009, msg = "OK", data = data });
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return Ok(new { code = 1011, msg = "Failed,please try again." });
            }
        }

        private static async Task SaveFile(IFormFile file, string path)
        {
            var dir = Path.GetDirectoryName(path);
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            await using var fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            await file.CopyToAsync(fs);
        }
    }
}