using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using WebsiteBanDienThoai.common.Helper;
using WebsiteBanDienThoai.EF;
using WebsiteBanDienThoai.Models;
using WebsiteBanDienThoai.common;
using WebsiteBanDienThoai.common.Message;
using Message = WebsiteBanDienThoai.common.Message.Message;

namespace WebsiteBanDienThoai.Controllers
{
    public class CartController : Controller
    {
        public dbFinal db = new dbFinal();
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult Add(int id)//theme vao gio hang
        {
            if (User.Identity.IsAuthenticated)
            {
                ShoppingCart.Cart.Add(id);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }

        }
        public ActionResult Remove(int id)//Xoas khoi gio hang
        {
            ShoppingCart.Cart.Remove(id);
            return RedirectToAction("Index");
        }
        public ActionResult Update()//theme vao gio hang
        {
            foreach (var p in ShoppingCart.Cart.Items)
            {
                p.SoLuong = int.Parse(Request[p.ID.ToString()]);
            }
            return RedirectToAction("Index");
        }
        public ActionResult Clear()//clear vao gio hang
        {
            ShoppingCart.Cart.Clear();
            return RedirectToAction("Index");
        }
        [Authorize]
        public ActionResult Checkout()
        {
            int userId = User.Identity.GetUserId();
            var user = db.Accounts.SingleOrDefault(u => u.account_id == userId);
            return View(user);
        }

    }
}