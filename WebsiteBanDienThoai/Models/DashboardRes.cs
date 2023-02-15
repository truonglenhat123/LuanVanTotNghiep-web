using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebsiteBanDienThoai.EF;

namespace WebsiteBanDienThoai.Models
{
    public class DashboardRes
    {
        public List<ProductBestSale> ProductBestSale {get; set; }
        public double TotalRevenue {get; set; }
    }
    public class ProductBestSale 
    {
        public Product Product { get; set; }

        public int Count { get; set; }
    }
}