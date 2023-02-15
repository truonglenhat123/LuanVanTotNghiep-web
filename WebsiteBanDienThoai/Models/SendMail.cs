using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebsiteBanDienThoai.Models
{
    public class SendMail
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Phone { get; set; }
        public string Message { get; set; }
        public string Email { get; set; }
    }
}