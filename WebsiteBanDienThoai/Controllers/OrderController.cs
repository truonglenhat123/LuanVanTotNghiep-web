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
            int userId = User.Identity.GetUserId();
            var user = db.Accounts.SingleOrDefault(u => u.account_id == userId);
            ViewBag.MyAddress = db.Accounts.FirstOrDefault(u => u.account_id == userId);
            var model = new OrderModel();
            model.payment_id = 1;
            model.account_id = User.Identity.GetUserId();
            model.create_by = User.Identity.GetName().ToString();
            model.status = "1";
            model.create_at = DateTime.Now;
            model.oder_date = DateTime.Now;
            model.update_by = User.Identity.GetName().ToString();
            model.update_at = DateTime.Now;
            model.update_by = User.Identity.GetUserId().ToString();
            model.customer_id = 1;
            model.employee_id = 1;
            model.total = ShoppingCart.Cart.Total;
            return View(model);
        }
        [Authorize]
        [HttpPost]
        public ActionResult Checkout(OrderModel model)
        {
            var order = new Order();
            order.addressShipping = model.addressShipping;
            order.phoneShipping = model.phoneShipping;
            order.status = "1";
            order.order_note = model.order_note;
            order.oder_date = model.oder_date;
            order.create_by = model.create_by;
            order.update_by = model.update_by;
            order.create_at = model.create_at;
            order.update_at = model.update_at;
            order.account_id = model.account_id;
            order.customer_id = model.customer_id;
            order.employee_id = model.employee_id;
            order.total = model.total;
            ShoppingCart.Cart.AppendToOrder(order);
            ShoppingCart.Cart.Clear();
            return RedirectToAction("Index","Home");
        }

    }
}