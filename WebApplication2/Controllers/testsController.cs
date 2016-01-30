using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;
//using Kendo.Mvc.Extensions;
//using Kendo.Mvc.UI;

namespace WebApplication2.Controllers
{
    public class testsController : Controller
    {
        private testEntities db = new testEntities();

        // GET: tests
       [RequireHttps]
        public ActionResult Index(string searchString)
        {
            var students = from s in db.tests
                          // join x in db.DatePersonales on s.id equals x.id - join versiunea linq
                           select s;
 
            //return View(db.tests.ToList());


            if (!string.IsNullOrEmpty(searchString))
            {
                students = students.Where(s => s.nume.Contains(searchString));
            }
            return View(students);
        }

        // GET: tests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            test test = db.tests.Find(id);
            if (test == null)
            {
                return HttpNotFound();
            }
            return View(test);
        }

        // GET: tests/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nume,DataNastere,facultate")] test test)
        {
            if (ModelState.IsValid)
            {
                db.tests.Add(test);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(test);
        }

        // GET: tests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            test test = db.tests.Find(id);
            if (test == null)
            {
                return HttpNotFound();
            }
            return View(test);
        }

        // POST: tests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nume,DataNastere,facultate")] test test)
        {
            if (ModelState.IsValid)
            {
                db.Entry(test).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(test);
        }

        // GET: tests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            test test = db.tests.Find(id);
            if (test == null)
            {
                return HttpNotFound();
            }
            return View(test);
        }

        // POST: tests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            test test = db.tests.Find(id);
            db.tests.Remove(test);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
     /*  public ActionResult Stud_read([DataSourceRequest] DataSourceRequest request) 
       {
            return Json(GetStudents().ToDataSourceResult(request));
        }

       public static IEnumerable<test> GetStudents()
        {
            var test = new testEntities();
            var students = from s in test.tests
                           select s;

            return students;

        }*/

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
