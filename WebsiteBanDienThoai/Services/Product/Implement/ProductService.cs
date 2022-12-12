using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebsiteBanDienThoai.EF;
using WebsiteBanDienThoai.Models;
using FeedbackNew = WebsiteBanDienThoai.EF.Feedback;

namespace WebsiteBanDienThoai.Services.Product.Implement
{
    public class ProductService : IProductService
    {
        dbFinal db = new dbFinal();
        public void AddFeedback(AddFeedback addFeedback)
        {
            FeedbackNew fb = new FeedbackNew();
            fb.product_id = addFeedback.ProductId;
            fb.Name = addFeedback.Name;
            fb.PhoneNumber = addFeedback.PhoneNumber;
            fb.Email = addFeedback.Email;
            fb.Content = addFeedback.Content;
            fb.RateStar = addFeedback.RateStar;
            fb.create_at = DateTime.Now;

            db.Feedbacks.Add(fb);
            db.SaveChanges();
        }
    }
}