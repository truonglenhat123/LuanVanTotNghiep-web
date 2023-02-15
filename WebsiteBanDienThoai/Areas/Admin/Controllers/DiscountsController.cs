using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing.Drawing2D;
using System.EnterpriseServices;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebsiteBanDienThoai.common.Helper;
using WebsiteBanDienThoai.EF;

namespace WebsiteBanDienThoai.Areas.Admin.Controllers
{
    public class DiscountsController : Controller
    {
        private dbFinal db = new dbFinal();

        // GET: Admin/Discounts
        public ActionResult Index()
        {
            return View(db.Discounts.ToList());
        }

        // GET: Admin/Discounts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Discount discount = db.Discounts.Find(id);
            if (discount == null)
            {
                return HttpNotFound();
            }
            return View(discount);
        }

        // GET: Admin/Discounts/Create
        public ActionResult Create()

        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Discount discount)

        {
            discount.discount_name = discount.discount_name;
            discount.discount_star = discount.discount_star;
            discount.discount_end = discount.discount_end;
            discount.discount_price=discount.discount_price;
            discount.discount_code = discount.discount_code;
            discount.create_at=DateTime.Now;
            discount.create_by=User.Identity.GetEmail();
            discount.update_at=DateTime.Now;
            discount.update_by=User.Identity.GetEmail();
            discount.quantity = discount.quantity;
            db.Discounts.Add(discount);
            db.SaveChanges();

            return RedirectToAction("Index");
        }


        // GET: Admin/Discounts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Discount discount = db.Discounts.Find(id);
            if (discount == null)
            {
                return HttpNotFound();
            }
            return View(discount);
        }

        // POST: Admin/Discounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "disscount_id,discount_name,discount_star,discount_end,discount_price,discount_code,create_at,create_by,update_by,update_at,quantity")] Discount discount)
        {
            if (ModelState.IsValid)
            {
                db.Entry(discount).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(discount);
        }

        // GET: Admin/Discounts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Discount discount = db.Discounts.Find(id);
            if (discount == null)
            {
                return HttpNotFound();
            }
            return View(discount);
        }

        // POST: Admin/Discounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Discount discount = db.Discounts.Find(id);
            db.Discounts.Remove(discount);
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
