using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebsiteBanDienThoai.EF;

namespace WebsiteBanDienThoai.Areas.Admin.Controllers
{
    public class OrdersController : Controller
    {
        private dbFinal db = new dbFinal();

        // GET: Admin/Orders
        public ActionResult Index(int? size, int? page)
        {
            var pageSize = size ?? 15;
            var pageNumber = page ?? 1;
            var orders = db.Orders.Include(o => o.Account).Include(o => o.Customer).Include(o => o.employee).Include(o => o.Payment);
            return View(orders.ToList());
        }

        // GET: Admin/Orders/Details/5
        public ActionResult Details(int? id)
        {

            Order order = db.Orders.FirstOrDefault(m => m.order_id == id);
            ViewBag.ListProduct = db.Oder_Detail.Where(m => m.order_id == order.order_id).ToList();
            ViewBag.OrderHistory = db.Orders.Where(m => m.account_id == order.account_id).OrderByDescending(m => m.oder_date).Take(10).ToList();
            //if (order == null)
            //{
            //    Notification.setNotification1_5s("Không tồn tại! (ID = " + id + ")", "warning");
            //    return RedirectToAction("Index");
            //}
            return View(order);
        }

        // GET: Admin/Orders/Create
        public ActionResult Create()
        {
            ViewBag.account_id = new SelectList(db.Accounts, "account_id", "password");
            ViewBag.customer_id = new SelectList(db.Customers, "customer_id", "customer_name");
            ViewBag.employee_id = new SelectList(db.employees, "employee_id", "employee_name");
            ViewBag.payment_id = new SelectList(db.Payments, "payment_id", "payment_name");
            return View();
        }

        // POST: Admin/Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "order_id,payment_id,oder_date,total,account_id,status,create_at,create_by,update_by,update_at,order_note,employee_id,customer_id,addressShipping,phoneShipping")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.account_id = new SelectList(db.Accounts, "account_id", "password", order.account_id);
            ViewBag.customer_id = new SelectList(db.Customers, "customer_id", "customer_name", order.customer_id);
            ViewBag.employee_id = new SelectList(db.employees, "employee_id", "employee_name", order.employee_id);
            ViewBag.payment_id = new SelectList(db.Payments, "payment_id", "payment_name", order.payment_id);
            return View(order);
        }

        // GET: Admin/Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.account_id = new SelectList(db.Accounts, "account_id", "password", order.account_id);
            ViewBag.customer_id = new SelectList(db.Customers, "customer_id", "customer_name", order.customer_id);
            ViewBag.employee_id = new SelectList(db.employees, "employee_id", "employee_name", order.employee_id);
            ViewBag.payment_id = new SelectList(db.Payments, "payment_id", "payment_name", order.payment_id);
            return View(order);
        }

        // POST: Admin/Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "order_id,payment_id,oder_date,total,account_id,status,create_at,create_by,update_by,update_at,order_note,employee_id,customer_id,addressShipping,phoneShipping")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.account_id = new SelectList(db.Accounts, "account_id", "password", order.account_id);
            ViewBag.customer_id = new SelectList(db.Customers, "customer_id", "customer_name", order.customer_id);
            ViewBag.employee_id = new SelectList(db.employees, "employee_id", "employee_name", order.employee_id);
            ViewBag.payment_id = new SelectList(db.Payments, "payment_id", "payment_name", order.payment_id);
            return View(order);
        }

        // GET: Admin/Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Admin/Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
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
