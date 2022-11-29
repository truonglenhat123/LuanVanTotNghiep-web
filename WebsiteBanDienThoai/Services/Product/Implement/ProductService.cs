using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebsiteBanDienThoai.EF;
using WebsiteBanDienThoai.Models;

namespace WebsiteBanDienThoai.Services.Product.Implement
{
    public class ProductService : IProductService
    {
        Model1 db = new Model1();
        public void AddFeedback(AddFeedback addFeedback)
        {
            //FeedbackNew fb = new FeedbackNew();
            //fb.product_id = addFeedback.ProductId;
            //fb.Name = addFeedback.Name;
            //fb.PhoneNumber = addFeedback.PhoneNumber;
            //fb.Email = addFeedback.Email;
            //fb.Content = addFeedback.Content;
            //fb.RateStar = addFeedback.RateStar;
            //fb.CreateTime  = DateTime.Now;

            //db.FeedbackNews.Add(fb);
            //db.SaveChanges();
        }
    }
}