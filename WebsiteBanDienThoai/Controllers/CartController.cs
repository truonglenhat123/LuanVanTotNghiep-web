using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using WebsiteBanDienThoai.common.Helper;
using WebsiteBanDienThoai.EF;
using WebsiteBanDienThoai.Models;
using WebsiteBanDienThoai.common;
using WebsiteBanDienThoai.common.Message;
using Message = WebsiteBanDienThoai.common.Message.Message;

namespace WebsiteBanDienThoai.Controllers
{
    public class CartController : Controller
    {
        public dbFinal db = new dbFinal();
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult Add(int id)//theme vao gio hang
        {
            if (User.Identity.IsAuthenticated)
            {
                ShoppingCart.Cart.Add(id);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }

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
        [Authorize]
        public ActionResult Checkout()
        {
            int userId = User.Identity.GetUserId();
            var user = db.Accounts.SingleOrDefault(u => u.account_id == userId);
            return View(user);
        }

        //public ActionResult ViewCart()
        //{
        //    var cart = this.GetCart();
        //    ViewBag.Quans = cart.Item2;
        //    var listProduct = cart.Item1.ToList();
        //    return View(listProduct);
        //}



        //[Authorize]
        //[HttpPost]
        //public async Task<ActionResult> SaveOrder(OrderModel orderModel, string note, string emailID, string orderID, string orderItem, string orderDiscount, string orderPrice, string orderTotal, string contentWard, string district, string province)
        //{
        //    try
        //    {
        //        var culture = System.Globalization.CultureInfo.GetCultureInfo("vi-VN");
        //        string productquancheck = "0";
        //        var order = new Order()
        //        {
        //            account_id = User.Identity.GetUserId(),
        //            create_at = DateTime.Now,
        //            create_by = User.Identity.GetUserId().ToString(),
        //            status = "1",
        //            order_note = "avc",
        //            customer_id = 1,
        //            employee_id = 1,
        //            addressShipping = orderModel.addressShipping,
        //            phoneShipping = orderModel.phoneShipping,
        //            order_id = 100,
        //            oder_date = DateTime.Now,
        //            update_at = DateTime.Now,
        //            payment_id = 1,
        //            update_by = User.Identity.GetUserId().ToString(),
        //            total = Convert.ToDouble(TempData["Total"])
        //        };

        //            db.Orders.Add(order);
        //        db.Configuration.ValidateOnSaveEnabled = false;
        //        await db.SaveChangesAsync();
        //        Message.setNotification3s("Đặt hàng thành công", "success");
        //        return RedirectToAction("index", "Home");
        //    }
        //    catch (Exception)
        //    {

        //      Message.setNotification3s("Lỗi! đặt hàng không thành công", "error");
        //        return RedirectToAction("Checkout", "Cart");
        //    }
        //}
        //private Tuple<List<Product>, List<int>> GetCart()
        //{
        //    //check null 
        //    var cart = Request.Cookies.AllKeys.Where(c => c.IndexOf("product_") == 0);
        //    var productIds = new List<int>();
        //    var quantities = new List<int>();
        //    var errorProduct = new List<string>();
        //    var cValue = "";
        //    // Lấy mã sản phẩm & số lượng trong giỏ hàng
        //    foreach (var item in cart)
        //    {
        //        var tempArr = item.Split('_');
        //        if (tempArr.Length != 2)
        //        {
        //            //Nếu không lấy được thì xem như sản phẩm đó bị lỗi
        //            errorProduct.Add(item);
        //            continue;
        //        }
        //        cValue = Request.Cookies[item].Value;
        //        productIds.Add(Convert.ToInt32(tempArr[1]));
        //        quantities.Add(Convert.ToInt32(String.IsNullOrEmpty(cValue) ? "0" : cValue));
        //        if (cValue == "0")
        //        {
        //            Response.Cookies["product_" + tempArr[1]].Expires = DateTime.Now;
        //        }
        //    }
        //    // Select sản phẩm để hiển thị
        //    var listProduct = new List<Product>();
        //    foreach (var id in productIds)
        //    {
        //        var product = db.Products.SingleOrDefault(p => p.status == "1" && p.ID == id);
        //        if (product != null)
        //        {
        //            listProduct.Add(product);
        //        }
        //        else
        //        {
        //            // Trường hợp ko chọn được sản phẩm như trong giỏ hàng
        //            // Đánh dấu sản phẩm trong giỏ hàng là sản phẩm lỗi
        //            errorProduct.Add("product-" + id);
        //            quantities.RemoveAt(productIds.IndexOf(id));
        //        }
        //    }
        //    //Xóa sản phẩm bị lỗi khỏi cart
        //    foreach (var err in errorProduct)
        //    {
        //        Response.Cookies[err].Expires = DateTime.Now.AddDays(-1);
        //    }
        //    return new Tuple<List<Product>, List<int>>(listProduct, quantities);//lấy id sản phẩm và số lượng
        //}
    }
}