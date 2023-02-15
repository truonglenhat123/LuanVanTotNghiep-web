using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebsiteBanDienThoai.EF;

namespace WebsiteBanDienThoai.Models
{
    public class ShoppingCart
    {
        dbFinal db = new dbFinal();
        public static ShoppingCart Cart
        {
            get { 
                var cart = HttpContext.Current.Session["Cart"] as ShoppingCart;
                if(cart == null)
                {
                    cart = new ShoppingCart();
                    HttpContext.Current.Session["Cart"] = cart;
                }
                return cart;
            }
        }
        public List<Product> Items = new List<Product>();

        public void Add(int id)
        {
            try
            {
                var item = Items.Single(i => i.ID == id);
                item.SoLuong++;
            }
            catch (Exception)
            {

                var db = new dbFinal();
                var p = db.Products.Find(id);
                p.SoLuong = 1;
                Items.Add(p);
            }
        }
        public void Remove(int id)
        {
            var item = Items.Single(m => m.ID == id);
            Items.Remove(item);  

        }
        public void Clear()
        {
            Items.Clear();
        }

        public double Total
        {
            get{
                return (double)Items.Sum(p => p.New_Price * p.SoLuong);
            }
        }
        public int Count
        {
            get
            {
                return Items.Count;
            }
        }

        public void AppendToOrder(Order order)
        {

            List<Oder_Detail> oder_Details = new List<Oder_Detail>();
            foreach (var item in Items)
            {
                var detail = new Oder_Detail
                {
                   
                    product_id = item.ID,
                    genre_id = item.genre_id,
                    disscount_id = item.disscount_id,
                    price = item.New_Price,
                    quantity = (int)item.SoLuong,
                    status = "1",
                    transection = "transection",
                    create_by = "173",
                    create_at = DateTime.Now,
                    update_by = "173",
                    update_at = DateTime.Now,


                };
                oder_Details.Add(detail);
            }
            order.Oder_Detail = oder_Details;
            db.Orders.Add(order);
            db.SaveChanges();
        }
    }
}