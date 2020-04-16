using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using AspBilCrud.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspBilCrud.Controllers
{
    public class ContactController : Controller
    {


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(ContactViewModel vm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    MailMessage msz = new MailMessage();
                    msz.From = new MailAddress(vm.Email);//Email which you are getting 
                                                         //from contact us page 
                    msz.To.Add("TheEmailAdresse");//Where mail will be sent 
                    msz.Subject = vm.Subject;
                  
                    msz.Body = string.Format("Navn: " + vm.Name +"<br> Email: "+ vm.Email + "<br> Besked: " + vm.Message);
                    msz.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient();

                    smtp.Host = "smtp.gmail.com";

                    smtp.Port = 587;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new System.Net.NetworkCredential
                    ("TheEmailAdresse", "ThePasswordForTheEmailAdresse");

                    smtp.EnableSsl = true;

                    smtp.Send(msz);

                    ModelState.Clear();
                    ViewBag.Message = "Tak, for at kontakte os.";
                }
                catch (Exception ex)
                {
                    ModelState.Clear();
                    ViewBag.Message = $" Der er dessværre et problem: {ex.Message}";
                }
            }

            return View();
        }
        public IActionResult Error()
        {
            return View();
        }

        
    }
}