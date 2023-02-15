using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebsiteBanDienThoai.EF;

namespace WebsiteBanDienThoai.Models
{
    public class ChiTietSanPham
    {
        public Product Product { get; set; }
        public AddFeedback AddFeedback { get; set; }
    }
}