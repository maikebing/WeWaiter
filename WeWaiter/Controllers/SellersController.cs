using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeWaiter.Data;

namespace WeWaiter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SellersController : ControllerBase
    {
        private readonly WeWaiterContext _context;

        public SellersController(WeWaiterContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 获取商家信息
        /// </summary>
        /// <param name="id">商家编码</param>
        /// <param name="seatid">座位编码，如果没有座位，则座位信息为空</param>
        /// <returns></returns>
        [HttpGet()]
        public async Task<IActionResult> GetSeller([FromQuery] string id, [FromQuery] int seatid)
        {
            if (!ModelState.IsValid)
            {
                return Ok(new { code = 1004, msg = "GetSeller ModelState invalid " });
            }
            try
            {
                var seller = await _context.Seller.FindAsync(id);
                if (seller == null)
                {
                    return Ok(new { code = 1009, msg = $"没有找到此商户{id}" }); ;
                }
                var catalogs = await (from c in _context.Catalog where c.SellerID == seller.SellerID && c.Deleted == false orderby c.OrderBy select c).ToListAsync();
                List<GoodsCatalog> cgs = new List<GoodsCatalog>();
                catalogs.ForEach(a =>
                {
                    var goods = (from g in _context.Goods where g.Seller == seller.SellerID && g.CatalogID == a.CatalogID && g.Deleted == false orderby g.Rating descending select g).ToList();
                    cgs.Add(new GoodsCatalog()
                    {
                        CatalogID = a.CatalogID,
                        CatalogName = a.CatalogName,
                        OrderBy = a.OrderBy,
                        Goods = goods
                    });
                });
                var sits = from g in _context.Seat where g.Seller == id && g.SeatNumber == seatid select g;
                var data = new { seller, Catalogs = cgs.ToArray(), Seat = await sits.FirstOrDefaultAsync() };
                return Ok(new { code = 1009, msg = "OK", seller = data });
            }
            catch (Exception ex)
            {
                return Ok(new { code = 1011, msg = ex.Message });
            }
        }

        private bool SellerExists(string id)
        {
            return _context.Seller.Any(e => e.SellerID == id);
        }
    }
}