using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebsiteBanDienThoai.common.Helper;
using WebsiteBanDienThoai.common.Message;
using WebsiteBanDienThoai.DTO;
using WebsiteBanDienThoai.EF;

namespace WebsiteBanDienThoai.Areas.Admin.Controllers
{
    public class ProductsAdminController : Controller
    {
        private dbFinal db = new dbFinal();

       

        // GET: Admin/Product
        public ActionResult Index(string search, int? size, int? page)
        {
            var pageSize = size ?? 15;
            var pageNumber = page ?? 1;
            var list = from a in db.Products
                       join c in db.Genres on a.genre_id equals c.genre_id
                       join d in db.Brands on a.brand_id equals d.brand_id
                       where a.status == "1"
                       orderby a.create_at descending
                       select new ProductDTO
                       {


                           ProductName = a.ProductName,
                           SoLuong = a.SoLuong,
                           New_Price = a.New_Price,
                           image = a.image,
                           genre_name = c.genre_name,
                           brand_name = d.brand_name,
                           Id = a.ID,



                           brand_id = a.brand_id,
                       };
            return View(list.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult Details(int? id)
        {
            Product product = db.Products.FirstOrDefault(m => m.ID == id);
            if (product == null)
            {
                Message.setNotification1_5s("Không tồn tại! (ID = " + id + ")", "warning");
                return RedirectToAction("Index");
            }
            return View(product);
        }
        public ActionResult Create() //Tạo sản phẩm
        {
            ViewBag.ListDiscount =
               new SelectList(db.Discounts.OrderBy(m => m.discount_price), "disscount_id", "discount_name", 0);
            ViewBag.ListBrand = new SelectList(db.Brands, "brand_id", "brand_name", 0);
            ViewBag.ListGenre = new SelectList(db.Genres, "genre_id", "genre_name", 0);

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(Product product)
        {
            ViewBag.ListDiscount =
                new SelectList(db.Discounts.OrderBy(m => m.discount_price), "disscount_id", "discount_name", 0);
            ViewBag.ListBrand = new SelectList(db.Brands, "brand_id", "brand_name", 0);
            ViewBag.ListGenre = new SelectList(db.Genres, "genre_id", "genre_name", 0);
            try
            {
                if (product.ImageUpload != null)
                {
                    var fileName = Path.GetFileNameWithoutExtension(product.ImageUpload.FileName);
                    var extension = Path.GetExtension(product.ImageUpload.FileName);
                    fileName = fileName + DateTime.Now.ToString("HH-mm-dd-MM-yyyy") + extension;
                    product.image = "/Assets/Images/" + fileName;
                    product.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Assets/Images/"), fileName));
                }
                else
                {
                    Message.setNotification3s("Vui lòng thêm Ảnh Thumbnail!", "error");
                    return View(product);
                }
                product.status = "1";
                product.CPU = product.CPU;
                product.ram = product.ram;
                product.pin = product.pin;
                product.bonhotrong = product.bonhotrong;
                product.cameraSau = product.cameraSau;
                product.cameraTruoc = product.cameraTruoc;
                product.Color = product.Color;
                product.dophangiaiManHinh = product.dophangiaiManHinh;
                product.heDieuHanh = product.heDieuHanh;
                product.New_Price = product.New_Price;
                product.ProductName = product.ProductName;
                product.SoLuong = product.SoLuong;
                product.CreateDate = DateTime.Now;
                product.create_at = DateTime.Now;
                product.Description = product.Description;
                product.Descriptionshort = product.Descriptionshort;
                product.create_by = User.Identity.GetUserId().ToString();
                db.Products.Add(product);
                db.SaveChanges();
                Message.setNotification1_5s("Thêm mới thành công!", "success");
                return RedirectToAction("Index");
            }
            catch
            {
                Message.setNotification1_5s("Lỗi", "error");
                return View(product);
            }
        }
        public ActionResult Edit(int? id)
        {
            ViewBag.ListDiscount = new SelectList(db.Discounts.OrderBy(m => m.discount_price), "disscount_id", "discount_name", 0);
            ViewBag.ListBrand = new SelectList(db.Brands, "brand_id", "brand_name", 0);
            ViewBag.ListGenre = new SelectList(db.Genres, "genre_id", "genre_name", 0);
            var product = db.Products.FirstOrDefault(x => x.ID == id);
            if (product == null || id == null)
            {
                Message.setNotification1_5s("Không tồn tại! (ID = " + id + ")", "warning");
                return RedirectToAction("Index");
            }

            return View(product);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(Product model)
        {
            ViewBag.ListBrand = new SelectList(db.Brands, "brand_id", "brand_name", 0);
            ViewBag.ListGenre = new SelectList(db.Genres, "genre_id", "genre_name", 0);
            var product = db.Products.SingleOrDefault(x => x.ID == model.ID);
            try
            {
                if (model.ImageUpload != null)
                {
                    var fileName = Path.GetFileNameWithoutExtension(model.ImageUpload.FileName);
                    var extension = Path.GetExtension(model.ImageUpload.FileName);
                    fileName = fileName + extension;
                    product.image = "/Assets/Images/" + fileName;
                    model.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Assets/Images/"), fileName));
                }
                product.ProductName = model.ProductName;
                product.SoLuong = model.SoLuong;
                product.Description = model.Description;
                product.Descriptionshort = model.Descriptionshort;
                product.New_Price = model.New_Price;
                product.brand_id = model.brand_id;
                product.genre_id = model.genre_id;
                product.create_at = DateTime.Now;
                product.create_by = User.Identity.GetName();
                product.CreateDate = DateTime.Now;
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                Message.setNotification1_5s("Đã cập nhật lại thông tin!", "success");
                return RedirectToAction("Index");
            }
            catch
            {
                Message.setNotification1_5s("Lỗi", "error");
                return View(model);
            }
        }
        public ActionResult Delete()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult
        Delete(int id)
        {
            
            
                var data = db.Products.FirstOrDefault(x => x.ID == id);
                if (data != null)
                {
                db.Products.Remove(data);
                db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                    return View();
            
        }
    }
}