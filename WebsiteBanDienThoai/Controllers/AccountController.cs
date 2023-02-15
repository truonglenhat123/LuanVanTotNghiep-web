using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web.Helpers;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Security;
using WebsiteBanDienThoai.common;
using WebsiteBanDienThoai.common.Message;
using WebsiteBanDienThoai.EF;
using WebsiteBanDienThoai.Models;

namespace WebsiteBanDienThoai.Controllers
{
    public class AccountController : Controller
    {
        dbFinal db = new dbFinal();
        // GET: Account
        public ActionResult Login(string returnUrl)
        {
            if (String.IsNullOrEmpty(returnUrl) && Request.UrlReferrer != null && Request.UrlReferrer.ToString().Length > 0)
            {
                return RedirectToAction("Login", new { returnUrl = Request.UrlReferrer.ToString() });
            }
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            model.Password = Crypto.Hash(model.Password);
            Account account = db.Accounts.FirstOrDefault(m => m.email == model.Email && m.password == model.Password);
            if (account != null)
            {
                LoginData userData = new LoginData
                {
                    Id = account.account_id,
                    Fullname = account.Name,
                    Email = account.email,
                    Avatar = account.Avatar,
                    Phone = account.Phone,
                    Role = account.Role,
                    Status = account.status,

                };
                Message.setNotification1_5s("Đăng nhập thành công", "success");
                FormsAuthentication.SetAuthCookie(JsonConvert.SerializeObject(userData), false);
                if (!String.IsNullOrEmpty(returnUrl))
                    return Redirect(returnUrl);
                else
                    return RedirectToAction("Index", "Home");
            }
            Message.setNotification3s("Email, mật khẩu không đúng, hoặc tài khoản bị vô hiệu hóa", "error");
            return View(model);
        }
        //Đăng xuất tài khoản
        public ActionResult Logout(string returnUrl)
        {
            //if (String.IsNullOrEmpty(returnUrl) && Request.UrlReferrer != null && Request.UrlReferrer.ToString().Length > 0)
            //{
            //    return RedirectToAction("Logout");//tạo url khi đăng xuất, đăng xuất thành công thì quay lại trang trước đó
            //}
            FormsAuthentication.SignOut();
           
            if (!String.IsNullOrEmpty(returnUrl))
                return Redirect(returnUrl);
            else
                return RedirectToAction("Index", "Home");
        }
        //View đăng ký
        public ActionResult Register()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model,Account account )
        {
            string fail = "";
            string sucess = "";
            var checkEmail = db.Accounts.Any(m => m.email == model.Email);
            if(checkEmail)
            {
                fail = "email da duoc su dung";
                return View();
            }
            account.Role=Const.ROLE_MEMBER_CODE;
            account.status = "1";
            account.Role = 1;
            account.email = model.Email;
            account.create_by = model.Email;
            account.update_by = model.Email;
            account.Name = model.Name;
            account.Phone = model.Phone;
            account.update_at = DateTime.Now;
            db.Configuration.ValidateOnSaveEnabled = false;
            account.password = Crypto.Hash(model.Password);
            account.create_at = DateTime.Now;
            db.Accounts.Add(account);
            db.SaveChanges();
            sucess = "<script>alert('Đăng ký thành công');</script>";
            ViewBag.Success = sucess;
            ViewBag.Fail = fail;
            return RedirectToAction("Login", "Account");
        }
      
        
    }
}