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
    public class OrdersController : ControllerBase
    {
        private readonly WeWaiterContext _context;

        public OrdersController(WeWaiterContext context)
        {
            _context = context;
        }
        [HttpGet("GetMyOrders")]
        public IEnumerable<Order> GetMyOrders([FromQuery] string userid)
        {
            return _context.Order.Where(o => o.UserID == userid).OrderByDescending(o => o.Create);
        }

        [HttpGet("GetMyOrdersInSeller")]
        public IEnumerable<Order> GetMyOrdersInSeller([FromQuery] string sellerid, [FromQuery] string userid)
        {
            return _context.Order.Where(o=> o.UserID==userid && o.SellerID==sellerid).OrderByDescending(o=>o.Create);
        }

        // GET: api/Orders/5
        [HttpGet("GetSingerOrder")]
        public async Task<IActionResult> GetSingerOrder([FromQuery] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var order = await _context.Order.FindAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }
 
        // POST: api/Orders
        [HttpPost("CreateOrder")]
        public async Task<IActionResult> CreateOrder([FromBody] NewOrder order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            order.OrderID = Guid.NewGuid().ToString();
            order.Create = DateTime.Now;
            order.BuyItems.ForEach(async a =>
            {
                a.BuyItemID = Guid.NewGuid().ToString();
                a.OrderID = order.OrderID;
                var goods = await _context.Goods.FindAsync(a.GoodsID);
                a.UnitPrice = goods.SellingPrice;
                a.Amount = a.UnitPrice * a.Total;
                _context.BuyItem.Add(a);
                order.TotalPrice += a.Amount;
                });
         int  sellerordercount = await _context.Order.CountAsync(o => o.SellerID == order.SellerID && o.Create.Date.Equals(DateTime.Now.Date));
            order.OrderIndex = sellerordercount+1;
            _context.Order.Add(order);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetOrder", new { id = order.OrderID }, order);
        }

        //// DELETE: api/Orders/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteOrder([FromRoute] string id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var order = await _context.Order.FindAsync(id);
        //    if (order == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Order.Remove(order);
        //    await _context.SaveChangesAsync();

        //    return Ok(order);
        //}

        private bool OrderExists(string id)
        {
            return _context.Order.Any(e => e.OrderID == id);
        }
    }
}