using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebsiteBanDienThoai.EF;

namespace WebsiteBanDienThoai.Models
{
    public class AddFeedback
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public string Content { get; set; }

        public int? RateStar { get; set; }
        public string PhoneNumber { get; set; }
        public int ProductId { get; set; }
    }
}