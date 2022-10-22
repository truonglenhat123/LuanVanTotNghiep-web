using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanDienThoai.Models;

namespace WebsiteBanDienThoai.Controllers
{
    public class HomeController : Controller
    {
        dbKL4Entities db = new dbKL4Entities();
        public ActionResult Index()
        {
            var listProductHome = db.SanPhams.ToList();
            return View(listProductHome);
        }

    }
}