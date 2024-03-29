﻿using PagedList;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Security.AccessControl;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Results;
using System.Web.Mvc;
using WebsiteBanDienThoai.common;
using WebsiteBanDienThoai.common.Helper;
using WebsiteBanDienThoai.common.Message;
using WebsiteBanDienThoai.EF;
using WebsiteBanDienThoai.Models;
using WebsiteBanDienThoai.Services.Product;
using WebsiteBanDienThoai.Services.Product.Implement;

namespace WebsiteBanDienThoai.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _productService = new ProductService();

        dbFinal db = new dbFinal();

        public ActionResult Iphone(int? page, string sortOrder)
        {
            ViewBag.Type = "Iphone";
            ViewBag.SortBy = "Iphone" + "?";
            ViewBag.CountProduct = db.Products.Where(m => m.brand_id == 15 && m.genre_id == 1).Count();
            return View("ProductList", GetProduct(m => m.brand_id == 15 && m.genre_id == 1, page, sortOrder));
        }
        public ActionResult SamSung(int? page, string sortOrder)
        {
            ViewBag.Type = "SamSung";
            ViewBag.SortBy = "SamSunghone" + "?";
            ViewBag.CountProduct = db.Products.Where(m => m.brand_id == 41 && m.genre_id == 1).Count();
            return View("ProductList", GetProduct(m => m.brand_id == 41 && m.genre_id == 1, page, sortOrder));
        }
        public ActionResult Oppo(int? page, string sortOrder)
        {
            ViewBag.Type = "Oppo";
            ViewBag.SortBy = "Oppo" + "?";
            ViewBag.CountProduct = db.Products.Where(m => m.brand_id == 42 && m.genre_id == 1).Count();
            return View("ProductList", GetProduct(m => m.brand_id == 42 && m.genre_id == 1, page, sortOrder));
        }
        public ActionResult Xiaomi(int? page, string sortOrder)
        {
            ViewBag.Type = "Xiaomi";
            ViewBag.SortBy = "Xiaomi" + "?";
            ViewBag.CountProduct = db.Products.Where(m => m.brand_id == 32 && m.genre_id == 1).Count();
            return View("ProductList", GetProduct(m => m.brand_id == 32 && m.genre_id == 1, page, sortOrder));
        }
        private IPagedList GetProduct(Expression<Func<Product, bool>> expr, int? page, string sortOrder)
        {
            int pageSize = 9; 
            int pageNumber = (page ?? 1);

            ViewBag.OrderDetail = db.Oder_Detail.ToList();
            ViewBag.CurrentSort = sortOrder;
            ViewBag.ResetSort = String.IsNullOrEmpty(sortOrder) ? "" : "";
            ViewBag.DateAscSort = sortOrder == "date_asc" ? "date_asc" : "date_asc";
            ViewBag.DateDescSort = sortOrder == "date_desc" ? "date_desc" : "date_desc";
            ViewBag.PopularSort = sortOrder == "popular" ? "popular" : "popular";
            ViewBag.PriceDescSort = sortOrder == "price_desc" ? "price_desc" : "price_desc";
            ViewBag.PriceAscSort = sortOrder == "price_asc" ? "price_asc" : "price_asc";
            ViewBag.NameAscSort = sortOrder == "name_asc" ? "name_asc" : "name_asc";
            ViewBag.NameDescSort = sortOrder == "name_desc" ? "name_desc" : "name_desc";
            var list = db.Products.Where(expr).OrderByDescending(m => m.ID).ToPagedList(pageNumber, pageSize);
            switch (sortOrder)
            {
                case "price_asc":
                    list = db.Products.Where(expr).OrderBy(m => (m.New_Price - m.Discount.discount_price)).ToPagedList(pageNumber, pageSize);
                    break;
                case "price_desc":
                    list = db.Products.Where(expr).OrderByDescending(m => (m.New_Price - m.Discount.discount_price)).ToPagedList(pageNumber, pageSize);
                    break;
                case "date_asc":
                    list = db.Products.Where(expr).OrderBy(m => m.create_at).ToPagedList(pageNumber, pageSize);
                    break;
                case "date_desc":
                    list = db.Products.Where(expr).OrderByDescending(m => m.create_at).ToPagedList(pageNumber, pageSize);
                    break;
                case "name_asc":
                    list = db.Products.Where(expr).OrderBy(m => m.ProductName).ToPagedList(pageNumber, pageSize);
                    break;
                case "name_desc":
                    list = db.Products.Where(expr).OrderByDescending(m => m.ProductName).ToPagedList(pageNumber, pageSize);
                    break;
                default:
                    list = db.Products.Where(expr).OrderByDescending(m => m.create_at).ToPagedList(pageNumber, pageSize);
                    break;
            }
            ViewBag.Showing = list.Count();
            return list;
        }
        public ActionResult ChiTietSanPham(int id)
        {
            var product = db.Products.SingleOrDefault(m => m.status == "1" && m.ID == id);
            if (product == null)
            {
                return Redirect("/");
            }
            var feedbacks = db.Feedbacks.Where(x => x.product_id == id).ToList();
            ViewBag.relatedproduct = db.Products.Where(item => item.status == "1" && item.ID != product.ID && item.genre_id == product.genre_id && item.brand_id == product.brand_id).Take(8).ToList();
            //ViewBag.ListFeedback = db.Feedbacks.Where(m => m.stastus == "2").ToList();
            ViewBag.ListFeedback = feedbacks;
            ViewBag.CountFeedback = db.Feedbacks.Where(m => m.product_id == product.ID).Count();

            ChiTietSanPham ctsp = new ChiTietSanPham();
            ctsp.Product = product;
            return View(ctsp);
        }

        [HttpPost]
        public ActionResult AddReview(AddFeedback addFeedback)
        {
            _productService.AddFeedback(addFeedback);
            string message = "SUCCESS";
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });
        }

    }
}