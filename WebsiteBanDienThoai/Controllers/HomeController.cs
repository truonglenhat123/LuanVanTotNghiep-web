using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanDienThoai.EF;
using WebsiteBanDienThoai.Models;

namespace WebsiteBanDienThoai.Controllers
{
    public class HomeController : Controller
    {
        dbFinal db = new dbFinal();
        public ActionResult Index()
        {
            ViewBag.HotProduct = db.Products.Where(item =>item.hot == true && item.SoLuong !=0 ).Take(8).ToList();
            ViewBag.Iphone = db.Products.Where(item => item.genre_id == 1 && item.SoLuong != 0 && item.brand_id==15).Take(4).ToList();
            ViewBag.SamSung = db.Products.Where(item =>  item.genre_id == 1 && item.SoLuong != 0 && item.brand_id == 41).Take(4).ToList();
            ViewBag.Xiaomi = db.Products.Where(item => item.genre_id == 1 && item.SoLuong != 0 && item.brand_id == 32).Take(4).ToList();
            ViewBag.Oppo = db.Products.Where(item => item.genre_id == 1 && item.SoLuong != 0 && item.brand_id == 42).Take(4).ToList();

            return View();
        }
        public ActionResult PageNotFound()
        {
            return View();
        }

    }
}