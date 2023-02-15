using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Configuration;
using System.Net.Mail;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using WebsiteBanDienThoai.common;
using WebsiteBanDienThoai.Models;

namespace WebsiteBanDienThoai.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {

            return View();

        }
        [HttpPost]
        public ActionResult Index(SendMail model)
        {

            SmtpClient smtpClient = new SmtpClient();
             MailMessage message = new MailMessage();
            message.From = new MailAddress("kieubob123@gmail.com"); 
            message.To.Add(model.Email);
            message.Subject = model.Subject;
            message.Body = model.Message;
            message.IsBodyHtml = true;
            try
            {
                smtpClient.Host = "smtp.gmail.com";
                smtpClient.Port = 587;
                smtpClient.EnableSsl = true;
                smtpClient.Credentials = (ICredentialsByHost)new NetworkCredential("kieubob123@gmail.com", "nmutmfydsiyahnlv");
                smtpClient.Send(message);
                ViewBag.Message = "Email sent sucessfully.";
                return View();
            }
            catch (Exception ex)
            {
                this.Session["ExceptionName"] = ex.GetType().ToString();
                this.Session["ExceptionDescription"] = ex.Message.ToString();
                return View();
            }

            return View();
        }

    }
}