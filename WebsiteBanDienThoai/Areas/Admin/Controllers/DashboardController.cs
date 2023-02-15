using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanDienThoai.EF;
using WebsiteBanDienThoai.Models;

namespace WebsiteBanDienThoai.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        public dbFinal db = new dbFinal();
        // GET: Admin/Home
        public ActionResult Index()
        {
            DashboardRes dashboardRes = new DashboardRes();

            ViewBag.Order = db.Orders.ToList();
            ViewBag.OrderDetail = db.Oder_Detail.ToList();
            ViewBag.ListOrder = db.Orders.Take(7).ToList();
            ViewBag.ListOrderDetails = db.Oder_Detail.OrderByDescending(m => m.create_at).ToList();
            ViewBag.HotProduct = db.Products.Where(item => item.hot == true && item.SoLuong != 0).Take(8).ToList();

            var getProductBestSale = db.Oder_Detail.Where(item => item.create_at.Month == DateTime.Now.Month)
                .GroupBy(x => x.Product).Select(x => new ProductBestSale { Product = x.Key, Count = x.Sum(y=>y.quantity) })
                .OrderByDescending(x => x.Count).ToList();
            dashboardRes.ProductBestSale = getProductBestSale;

            var getTotalRevenue = db.Orders.Where(item => item.create_at.Month == DateTime.Now.Month)
                .Sum(x => x.total);

            dashboardRes.TotalRevenue = getTotalRevenue;

            return View(dashboardRes);
        }
    }
}