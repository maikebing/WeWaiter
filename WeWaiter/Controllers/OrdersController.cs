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

        [HttpGet()]
        public IEnumerable<ListOrder> GetOrders([FromQuery] string userid)
        {
            var orders= _context.Order.Where(o => o.UserID == userid ).OrderByDescending(o => o.Create);
            List<ListOrder> listOrder = new List<ListOrder>();
            orders.ForEachAsync(async a =>
            {
                var lo = a as ListOrder;
                lo.BuyItems = await _context.BuyItem.Where(b => b.OrderID == lo.OrderID).ToListAsync();
                lo.Seller = await _context.Seller.Where(s => s.SellerID == lo.SellerID).FirstOrDefaultAsync();
                listOrder.Add( lo                    );
            });
            return listOrder;
        }

 

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] NewOrder order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            IActionResult actionResult = NoContent();
            try
            {
                if (!await _context.User.AnyAsync(u => u.OpenID == order.UserID))
                {
                    actionResult = NotFound("User Not Found");
                }
                else
                {
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
                    int sellerordercount = await _context.Order.CountAsync(o => o.SellerID == order.SellerID && o.Create.Date.Equals(DateTime.Now.Date));
                    order.OrderIndex = sellerordercount + 1;
                    _context.Order.Add(order);
                    int result = await _context.SaveChangesAsync();
                    if (result > 0)
                    {
                        actionResult = Ok(order);
                    }
                    else
                    {
                        actionResult = NotFound("NotingToDo");
                    }
                }
            }
            catch (Exception ex)
            {
                actionResult = BadRequest(ex.Message);
            }
            return actionResult;
        }
       

        private bool OrderExists(string id)
        {
            return _context.Order.Any(e => e.OrderID == id);
        }
    }
}