using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class UsersController : Controller
    {
        private testEntities db = new testEntities();

        // GET: Users
        public ActionResult Index()
        {
            return View();
        }

        
        //[ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId, UserFullName, UserName, Password")] User user)//logica de adaugare useri in bd
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        public void HashPasswd()
        {
            ;
        }
    }
}