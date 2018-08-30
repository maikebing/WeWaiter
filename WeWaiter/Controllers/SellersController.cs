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
    public class SellersController : ControllerBase
    {
        private readonly WeWaiterContext _context;

        public SellersController(WeWaiterContext context)
        {
            _context = context;
        }

        //// GET: api/Sellers
        //[HttpGet]
        //public IEnumerable<Seller> GetSeller()
        //{
        //    return _context.Seller;
        //}

        // GET: api/Sellers/5
        [HttpGet()]
        public async Task<IActionResult> GetSeller([FromQuery] string id, [FromQuery] string seatid)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var seller = await _context.Seller.FindAsync(id);

            if (seller == null)
            {
                return NotFound();
            }
            var goods = from g in _context.Goods where g.Seller == seller.SellerID && g.Deleted == false orderby g.Rating descending select g;
            var sits = from g in _context.Seat where g.Seller == id && g.SeatId == seatid select g;
            var data = new { seller, goods = await goods.ToArrayAsync(), Seat=await sits.FirstOrDefaultAsync() };
            return Ok(data);
        }

        //// PUT: api/Sellers/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutSeller([FromRoute] string id, [FromBody] Seller seller)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != seller.SellerID)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(seller).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!SellerExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Sellers
        //[HttpPost]
        //public async Task<IActionResult> PostSeller([FromBody] Seller seller)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    _context.Seller.Add(seller);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetSeller", new { id = seller.SellerID }, seller);
        //}

        //// DELETE: api/Sellers/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteSeller([FromRoute] string id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var seller = await _context.Seller.FindAsync(id);
        //    if (seller == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Seller.Remove(seller);
        //    await _context.SaveChangesAsync();

        //    return Ok(seller);
        //}

        private bool SellerExists(string id)
        {
            return _context.Seller.Any(e => e.SellerID == id);
        }
    }
}