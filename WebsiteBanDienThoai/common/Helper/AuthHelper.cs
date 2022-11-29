using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using WebsiteBanDienThoai.Models;

namespace WebsiteBanDienThoai.common.Helper
{
    public static class AuthHelper
    {
       
        public static string GetName(this IIdentity identity)
        {
            return identity.GetUserData().Fullname;
        }
        public static int GetUserId(this IIdentity identity)
        {
            return identity.GetUserData().Id;
        }
        public static string GetEmail(this IIdentity identity)
        {
            return identity.GetUserData().Email;
        }
        public static string GetAvatar(this IIdentity identity)
        {
            return identity.GetUserData().Avatar;
        }
        public static int GetRole(this IIdentity identity)
        {
            return identity.GetUserData().Role;
        }
        public static LoginData GetUserData(this IIdentity identity)
        {
            var jsonUserData = HttpContext.Current.User.Identity.Name;
            var userData = JsonConvert.DeserializeObject<LoginData>(jsonUserData);
            return userData;
        }
    }
}