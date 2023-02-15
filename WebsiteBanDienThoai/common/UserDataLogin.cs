using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsiteBanDienThoai.common
{
    public class UserDataLogin
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Avatar { get; set; }
        public int RoleCode { get; set; }
    }
}