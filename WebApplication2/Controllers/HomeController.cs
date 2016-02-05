using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using WebApplication2.Models;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.IO;
using System.Text;
using WebApplication2.Alg; //here we have Quicksort alghoritm implemented

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            int[] array = new int[] { 1, 12, 5, 26, 7, 14, 3, 7, 2, 4, 16 };
            int arrayLength = array.Length;
            Qsort.QuickSort(array, array[0], arrayLength - 1);
            for (int i = 0; i < array.Length; i++)
                ViewBag.QuickSort = array;


            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Vectorul este sortat";
            int [] array = new int[] { 5, 8, 9, 6};
            int temp;
            int arrayLength = array.Length;
            for (int i = 0; i < arrayLength; i++)
            {
                for (int j = 0; j < arrayLength - 1; j++)
                {
                    if (array[i] > array[j])
                    {
                        temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }

            for (int i = 0; i < arrayLength; i++)
                  ViewBag.VectorSortat = array; 
            
           
           return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Contact(EmailFormModel model)
        {
            if (ModelState.IsValid)
            {
                var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress(model.ToEmail));
                message.From = new MailAddress(model.FromEmail);
                message.Subject = "test";
                message.Body = string.Format(body, model.FromName, model.FromEmail, model.Message);
                message.IsBodyHtml = true;
                message.Attachments.Add(new Attachment(model.File.InputStream, Path.GetFileName(model.File.FileName)));

                using (SmtpClient smtp = new SmtpClient())
                {
                    NetworkCredential credetial = new NetworkCredential
                    {
                        UserName = model.FromEmail, Password = model.Password
                    };

                    smtp.Credentials = credetial;
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(message);

                    return RedirectToAction("Sent");
                }
            }

            return View(model);
        }

        [HttpPost]
        public  void WriteInFileFromKendoEditor(Content c)
        {
            if (ModelState.IsValid)
            {
                using (StreamWriter streamWriter = new StreamWriter(@"C:\Users\Cosmin\Desktop\FacultateAn4\test.txt", true))// apped to current file the new content
                {
                   streamWriter.WriteLine(c.content, "\n");
                   streamWriter.Close();
                   streamWriter.Dispose();
                }
            }
            else
            {
                ;//throw a message error to user
            }
            
        }

        public ActionResult Sent()
        {
            return View();
        }

        public ActionResult Chat()
        {
            return View();
        }
    }
}