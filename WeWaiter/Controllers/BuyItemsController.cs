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
    public class BuyItemsController : ControllerBase
    {
        private readonly WeWaiterContext _context;

        public BuyItemsController(WeWaiterContext context)
        {
            _context = context;
        }

        // GET: api/BuyItems
        [HttpGet]
        public IEnumerable<BuyItem> GetBuyItem()
        {
            return _context.BuyItem;
        }

        // GET: api/BuyItems/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBuyItem([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var buyItem = await _context.BuyItem.FindAsync(id);

            if (buyItem == null)
            {
                return NotFound();
            }

            return Ok(buyItem);
        }

        // PUT: api/BuyItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBuyItem([FromRoute] string id, [FromBody] BuyItem buyItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != buyItem.BuyItemID)
            {
                return BadRequest();
            }

            _context.Entry(buyItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BuyItemExists(id))
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

        // POST: api/BuyItems
        [HttpPost]
        public async Task<IActionResult> PostBuyItem([FromBody] BuyItem buyItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.BuyItem.Add(buyItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBuyItem", new { id = buyItem.BuyItemID }, buyItem);
        }

        // DELETE: api/BuyItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBuyItem([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var buyItem = await _context.BuyItem.FindAsync(id);
            if (buyItem == null)
            {
                return NotFound();
            }

            _context.BuyItem.Remove(buyItem);
            await _context.SaveChangesAsync();

            return Ok(buyItem);
        }

        private bool BuyItemExists(string id)
        {
            return _context.BuyItem.Any(e => e.BuyItemID == id);
        }
    }
}