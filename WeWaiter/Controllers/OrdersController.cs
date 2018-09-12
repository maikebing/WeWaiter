using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WeWaiter.DataBase;
using WeWaiter.Utils;

namespace WeWaiter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrdersController : ControllerBase
    {
        private readonly WeWaiterContext _context;

        public OrdersController(WeWaiterContext context)
        {
            _context = context;
        }

        [HttpGet()]
        public IActionResult GetOrders()
        {
            try
            {
                var userid = Request.GetJwtSecurityToken()?.GetUserId();
                var orders = _context.Order.Where(o => o.UserID == userid).OrderByDescending(o => o.Create);
                List<Orders> listOrder = new List<Orders>();
                 orders.ToList().ForEach(  a =>
                {
                    try
                    {
                        var lo = new Orders() { Order = a };
                        lo.BuyItems =  _context.BuyItem.Where(b => b.OrderID == lo.Order.OrderID).ToList();
                        lo.Seller =  _context.Seller.Where(s => s.SellerID == lo.Order.SellerID).FirstOrDefault();
                        listOrder.Add(lo);
                    }
                    catch (Exception)
                    {

                    }
                });
                return Ok(new { code = 0, msg = "OK",Orders= listOrder });
            }
            catch (Exception ex)
            {
                return Ok(new { code = 1005, msg = ex.Message });
            }
        }



        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] NewOrder order)
        {
            if (!ModelState.IsValid)
            {
                return Ok(new { code = 1004, msg = "CreateOrder ModelState invalid " });
            }
            IActionResult actionResult = NoContent();
            try
            {
                var userid = Request.GetJwtSecurityToken()?.GetUserId();
                if (string.IsNullOrEmpty(userid) || !await _context.User.AnyAsync(u => u.UserID == userid))
                {
                    actionResult = Ok(new { code = 1003, msg = $"用户[{userid}]未找到" });
                }
                else
                {
                    order.OrderID = Guid.NewGuid().ToString();
                    order.Create = DateTime.Now;
                    order.UserID = userid;
                    var seat= await _context.Seat.FirstOrDefaultAsync(s => s.SeatNumber == order.SeatNumber);
                    order.SeatID = seat?.SeatId;
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
                        actionResult = Ok(new { code = 0, msg = "OK", order });
                    }
                    else
                    {
                        actionResult = Ok(new { code = 1001, msg = "订单未能保存" });
                    }
                }
            }
            catch (Exception ex)
            {
                actionResult = Ok(new { code = 1002, msg = ex.Message }); ;
            }
            return actionResult;
        }


        private bool OrderExists(string id)
        {
            return _context.Order.Any(e => e.OrderID == id);
        }
    }
}