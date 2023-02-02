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

        //Code xử lý đăng nhập
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
            if (String.IsNullOrEmpty(returnUrl) && Request.UrlReferrer != null && Request.UrlReferrer.ToString().Length > 0)
            {
                return RedirectToAction("Logout", new { returnUrl = Request.UrlReferrer.ToString() });//tạo url khi đăng xuất, đăng xuất thành công thì quay lại trang trước đó
            }
            FormsAuthentication.SignOut();
            Message.setNotification1_5s("Đăng xuất thành công", "success");
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
        //View quên mật khẩu
        public ActionResult ForgotPassword()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        //[HttpPost]
        //public ActionResult ForgotPassword(ForgotPasswordViewModels model)
        //{
        //    Account account = db.Accounts.Where(m => m.email == model.Email).FirstOrDefault();
        //    if (account != null)
        //    {
        //        //Send email for reset password
        //        string resetCode = Guid.NewGuid().ToString();
        //        SendVerificationLinkEmail(account.email, resetCode);
        //        string sendmail = account.email;
        //        account.Requestcode = resetCode;        
        //        db.Configuration.ValidateOnSaveEnabled = false;
        //        db.SaveChanges();
        //    }
        //    else
        //    {
        //        Message.setNotification1_5s("Email chưa tồn tại trong hệ thống", "error");
        //    }
        //    return View(model);
        //}
        //public void SendVerificationLinkEmail(string emailID, string activationCode)
        //{
        //    var verifyUrl = "/Account/ResetPassword/" + activationCode;
        //    var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verifyUrl);
        //    var fromEmail = new MailAddress(EmailConfig.emailID, EmailConfig.emailName);
        //    var toEmail = new MailAddress(emailID);
        //    var fromEmailPassword = EmailConfig.emailPassword;
        //    string body = System.IO.File.ReadAllText(HostingEnvironment.MapPath("~/EmailTemplate/") + "ResetPassword" + ".cshtml");
        //    string subject = "Cập nhật mật khẩu mới";
        //    body = body.Replace("{{viewBag.Confirmlink}}", link); 
        //    body = body.Replace("{{viewBag.Confirmlink}}", Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verifyUrl));
        //    var smtp = new SmtpClient
        //    {
        //        Host = "smtp.gmail.com",
        //        Port = 587,
        //        EnableSsl = true,
        //        DeliveryMethod = SmtpDeliveryMethod.Network,
        //        UseDefaultCredentials = false,
        //        Credentials = new NetworkCredential(fromEmail.Address, fromEmailPassword)
        //    };

        //    using (var message = new MailMessage(fromEmail, toEmail)
        //    {
        //        Subject = subject,
        //        Body = body,
        //        IsBodyHtml = true
        //    })
        //        smtp.Send(message);
        //}
        //public ActionResult Resetpassword(string id)
        //{
        //    var user = db.Accounts.Where(a => a.Requestcode == id).FirstOrDefault();
        //    if (user != null && !User.Identity.IsAuthenticated)
        //    {
        //        ResetPasswordViewModels model = new ResetPasswordViewModels();
        //        model.ResetCode = id;
        //        return View(model);
        //    }
        //    else
        //    {
        //        return RedirectToAction("Index", "Home");
        //    }
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult ResetPassword(ResetPasswordViewModels model)
        //{
        //    var user = db.Accounts.Where(m => m.Requestcode == model.ResetCode).FirstOrDefault();
        //    if (user != null)
        //    {
        //        user.password = Crypto.Hash(model.NewPassword);
        //        //sau khi đổi mật khẩu thành công khi quay lại link cũ thì sẽ không đôi được mật khẩu nữa 
        //        user.Requestcode = "";
        //        user.update_by = user.email;
        //        user.update_at = DateTime.Now;
        //        user.status = "1";
        //        db.Configuration.ValidateOnSaveEnabled = false;
        //        db.SaveChanges();
        //        Message.setNotification1_5s("Cập nhật mật khẩu thành công", "success");
        //        return RedirectToAction("Login");
        //    }
        //    return View(model);
        //}
    }
}