using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanDienThoai.EF;

namespace WebsiteBanDienThoai.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        public dbFinal db = new dbFinal();
        // GET: Admin/Home
        public ActionResult Index()
        {
            ViewBag.Order = db.Orders.ToList();
            ViewBag.OrderDetail = db.Oder_Detail.ToList();
            ViewBag.ListOrder = db.Orders.Take(7).ToList();
            ViewBag.ListOrderDetails = db.Oder_Detail.OrderByDescending(m=>m.create_at).ToList();
            ViewBag.HotProduct = db.Products.Where(item => item.hot == true && item.SoLuong != 0).Take(8).ToList();
            return View();
        }
    }
}