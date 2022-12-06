using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanDienThoai.EF;
using WebsiteBanDienThoai.Models;

namespace WebsiteBanDienThoai.Controllers
{
    public class CartController : Controller
    {
        public Model1 db = new Model1();
        // GET: Cart
        public ActionResult Index()
        {
            
            return View();
        }
        public ActionResult Add(int id)//theme vao gio hang
        {
            ShoppingCart.Cart.Add(id);
            return RedirectToAction("Index", "Home");
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

    }
}