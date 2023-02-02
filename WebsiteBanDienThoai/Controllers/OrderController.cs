using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanDienThoai.common.Helper;
using WebsiteBanDienThoai.EF;
using WebsiteBanDienThoai.Models;

namespace WebsiteBanDienThoai.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        dbFinal db = new dbFinal();
        public ActionResult Checkout()
        {
            var order = new Order();
            order.account_id = User.Identity.GetUserId();
            order.create_by = User.Identity.GetName().ToString();
            order.status = "1";
            order.create_at = DateTime.Now;
            order.oder_date = DateTime.Now;
            order.payment_id = 1;
            order.order_note = "abvadsadsad";
            order.update_by = User.Identity.GetName().ToString();
            order.update_at = DateTime.Now;
            order.update_by = User.Identity.GetUserId().ToString();
            order.customer_id = 1;
            order.employee_id = 1;
            order.total = ShoppingCart.Cart.Total;
            return View(order);
        }
            [Authorize]
        [HttpPost]
        public ActionResult Checkout(OrderModel model)
        {
            var order = new Order();
            order.account_id = User.Identity.GetUserId();
            order.create_by = User.Identity.GetName().ToString();
            order.status = "1";
            order.create_at = DateTime.Now;
            order.oder_date = DateTime.Now;
            order.payment_id = 1;
            order.order_note = "abvadsadsad";
            order.update_by = User.Identity.GetName().ToString();
            order.update_at = DateTime.Now;
            order.update_by = User.Identity.GetUserId().ToString();
            order.customer_id = 1;
            order.employee_id = 1;
            order.total = ShoppingCart.Cart.Total;
            ShoppingCart.Cart.AppendToOrder(order);
            ShoppingCart.Cart.Clear();
            return View(order);
        }
        
    }
}