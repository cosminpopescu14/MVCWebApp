using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;
using System.Web.Security;

namespace WebApplication2.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Login l)
        {
            if (ModelState.IsValid)
            {
                if (l.UserName == "cosmin" && l.Password == "1")//date corecte  logare
                {
                    FormsAuthentication.SetAuthCookie(l.UserName, false);
                    return RedirectToAction("Index", "tests");//redirectare la pagina 
                }

                {
                    ModelState.AddModelError("", "incorect creddetials... tyr again !!");
                }
            }
            return View();
        }
    }
}