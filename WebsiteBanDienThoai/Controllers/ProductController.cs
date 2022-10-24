using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using WebsiteBanDienThoai.Models;

namespace WebsiteBanDienThoai.Controllers
{
    public class ProductController : Controller
    {
        dbKL4Entities db = new dbKL4Entities();
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CategoryMenu()
        {
            var model = db.DanhMucs;
            return PartialView("_Category", model);
        }
        public ActionResult ChiTietSanPham(int id)
        {
            var model = db.SanPhams.Where(n => n.maSP == id).FirstOrDefault();
            return View(model);
        }
        public ActionResult ProductCategory(int categoryID = 0)
        {
            if (categoryID != 0)
            {
                var category = db.DanhMucs.Find(categoryID);
                var model1 = category.SanPhams.ToList();
                return View(model1);
            }

            var model = db.SanPhams.ToList();
            return View(model);
        }
        public ActionResult ProductList(int categoryID = 0)
        {
            if (categoryID != 0)
            {
                var category = db.DanhMucs.Find(categoryID);
                var model1 = category.SanPhams.ToList();
                return View(model1);
            }
            var model = db.SanPhams.ToList();
            return View(model);

        }
    }
}