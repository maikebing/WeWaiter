using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeWaiter.DataBase;

namespace WeWaiter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoodsController : ControllerBase
    {
        private readonly WeWaiterContext _context;

        public GoodsController(WeWaiterContext context)
        {
            _context = context;
        }

        // GET: api/Goods
        [HttpGet]
        public IEnumerable<Goods> GetGoods()
        {
            return _context.Goods;
        }

        // GET: api/Goods/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGoods([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var goods = await _context.Goods.FindAsync(id);

            if (goods == null)
            {
                return NotFound();
            }

            return Ok(goods);
        }

        // PUT: api/Goods/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGoods([FromRoute] string id, [FromBody] Goods goods)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != goods.GoodsID)
            {
                return BadRequest();
            }

            _context.Entry(goods).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GoodsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Goods
        [HttpPost]
        public async Task<IActionResult> PostGoods([FromBody] Goods goods)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Goods.Add(goods);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGoods", new { id = goods.GoodsID }, goods);
        }

        // DELETE: api/Goods/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGoods([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var goods = await _context.Goods.FindAsync(id);
            if (goods == null)
            {
                return NotFound();
            }

            _context.Goods.Remove(goods);
            await _context.SaveChangesAsync();

            return Ok(goods);
        }

        private bool GoodsExists(string id)
        {
            return _context.Goods.Any(e => e.GoodsID == id);
        }
    }
}