using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Web;
using FirstProjetNRT.Models;
using System.Security;
using System.Net;

namespace FirstProjetNRT.Controllers
{
    public class SendMailController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SendEmail()
        {
            return View();
        }


        [HttpPost]

        public ActionResult Index(string receiver, string subject, string message)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var senderEmail = new MailAddress("thierynjembele@gmail.com", "FCB");
                    var receiverEmail = new MailAddress(receiver, "Receiver");
                    var password = "ukqrfebdmqliooae";
                    var sub = subject;
                    var body = message;
                  //  System.Net.Mail.Attachment attachment;
                 //   attachment = new System.Net.Mail.Attachment(message);

                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(senderEmail.Address, password),
                        EnableSsl = true,
                    };


                    using (var mess = new MailMessage(senderEmail, receiverEmail)
                    {
                        Subject = subject,
                        Body = body
                       

                })
                    {
                        smtp.Send(mess);
                    }
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error =ex.ToString();
            }
            return View();
        }

    }
}
