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
        /// <summary>
        /// 返回订单的详细信息
        /// </summary>
        /// <param name="id">订单ID 0308c5a6-cbfe-49c7-92a0-c404342f480b</param>
        /// <returns>订单详细信息</returns>
        [HttpGet("{id}")]
        public IActionResult GetDetails([FromRoute] string id)
        {
            try
            {
                var userid = Request.GetJwtSecurityToken()?.GetUserId();
                var od = from o in _context.Order where o.UserID == userid && o.OrderID == id select o;
                var _order = od.FirstOrDefault();
                var order = new Orders() { Order = _order };
                order.BuyItems = _context.BuyItem.Where(b => b.OrderID == order.Order.OrderID).ToList();
                order.Seller = _context.Seller.Where(s => s.SellerID == order.Order.SellerID).FirstOrDefault();
                return Ok(new { code = 0, msg = "OK", data = order });
            }
            catch (Exception ex)
            {
                return Ok(new { code = 1005, msg = ex.Message });
            }
        }
        /// <summary>
        /// 当前登录用户的所有订单
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        public IActionResult GetOrders()
        {
            try
            {
                var userid = Request.GetJwtSecurityToken()?.GetUserId();

                var orders = _context.Order.Where(o => o.UserID == userid).OrderByDescending(o => o.Create);
                List<Orders> listOrder = new List<Orders>();
                orders.ToList().ForEach(a =>
             {
                 try
                 {
                     var lo = new Orders() { Order = a };
                     lo.BuyItems = _context.BuyItem.Where(b => b.OrderID == lo.Order.OrderID).ToList();
                     lo.Seller = _context.Seller.Where(s => s.SellerID == lo.Order.SellerID).FirstOrDefault();
                     listOrder.Add(lo);
                 }
                 catch (Exception)
                 {

                 }
             });
                return Ok(new { code = 0, msg = "OK", Orders = listOrder });
            }
            catch (Exception ex)
            {
                return Ok(new { code = 1005, msg = ex.Message });
            }
        }


        /// <summary>
        /// 提交订单信息 { "buyItems": [ { "Total": 2, "goodsID": "c805253d14fd4f62a28deb118c3759da" } ],"sellerID": "342c501a-3365-4c2f-816f-2aaf51ea7a39","SeatNumber":1}
        /// </summary>
        /// <param name="order">订单详情</param>
        /// <returns></returns>
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
                    var seat = await _context.Seat.FirstOrDefaultAsync(s => s.SeatNumber == order.SeatNumber);
                    order.SeatID = seat?.SeatId;
                    order.BuyItems.ForEach(async a =>
                    {
                        a.BuyItemID = Guid.NewGuid().ToString();
                        a.OrderID = order.OrderID;
                        var goods = await _context.Goods.FindAsync(a.GoodsID);
                        a.UnitPrice = goods.SellingPrice;
                        a.Total = a.UnitPrice * a.Amount;
                        a.GoodsName = goods.Name;
                        a.Icon = goods.Icon;
                        a.Image = goods.Image;
                        _context.BuyItem.Add(a);
                        order.TotalPrice += a.Total;
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