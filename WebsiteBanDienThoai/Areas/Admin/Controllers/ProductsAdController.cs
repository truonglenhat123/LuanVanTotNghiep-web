using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebsiteBanDienThoai.common.Helper;
using WebsiteBanDienThoai.EF;

namespace WebsiteBanDienThoai.Areas.Admin.Controllers
{
    public class ProductsAdController : Controller
    {
        private dbFinal db = new dbFinal();

        // GET: Admin/ProductsAd
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Brand).Include(p => p.Discount).Include(p => p.Genre);
            return View(products.ToList());
        }

        // GET: Admin/ProductsAd/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Admin/ProductsAd/Create
        public ActionResult Create()
        {
            ViewBag.brand_id = new SelectList(db.Brands, "brand_id", "brand_name");
            ViewBag.disscount_id = new SelectList(db.Discounts, "disscount_id", "discount_name");
            ViewBag.genre_id = new SelectList(db.Genres, "genre_id", "genre_name");
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ProductName,IsDelete,Old_Price,New_Price,image,hot,genre_id,CreateDate,Description,Descriptionshort,Color,kichThuocManHinh,dophangiaiManHinh,bonhotrong,cameraTruoc,cameraSau,ram,pin,sim,heDieuHanh,CPU,SoLuong,brand_id,status,create_by,create_at,disscount_id")] Product product)
        {
            if (ModelState.IsValid)
            {
                product.status = "1";
                product.CreateDate = DateTime.Now;
                product.create_at = DateTime.Now;
                product.create_by = User.Identity.GetUserId().ToString();
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.brand_id = new SelectList(db.Brands, "brand_id", "brand_name", product.brand_id);
            ViewBag.disscount_id = new SelectList(db.Discounts, "disscount_id", "discount_name", product.disscount_id);
            ViewBag.genre_id = new SelectList(db.Genres, "genre_id", "genre_name", product.genre_id);
            return View(product);
        }

        // GET: Admin/ProductsAd/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.brand_id = new SelectList(db.Brands, "brand_id", "brand_name", product.brand_id);
            ViewBag.disscount_id = new SelectList(db.Discounts, "disscount_id", "discount_name", product.disscount_id);
            ViewBag.genre_id = new SelectList(db.Genres, "genre_id", "genre_name", product.genre_id);
            return View(product);
        }

        // POST: Admin/ProductsAd/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ProductName,IsDelete,Old_Price,New_Price,image,hot,genre_id,CreateDate,Description,Descriptionshort,Color,kichThuocManHinh,dophangiaiManHinh,bonhotrong,cameraTruoc,cameraSau,ram,pin,sim,heDieuHanh,CPU,SoLuong,brand_id,status,create_by,create_at,disscount_id")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.brand_id = new SelectList(db.Brands, "brand_id", "brand_name", product.brand_id);
            ViewBag.disscount_id = new SelectList(db.Discounts, "disscount_id", "discount_name", product.disscount_id);
            ViewBag.genre_id = new SelectList(db.Genres, "genre_id", "genre_name", product.genre_id);
            return View(product);
        }

        // GET: Admin/ProductsAd/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Admin/ProductsAd/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
