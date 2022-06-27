using simpleApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace simpleApplication.Controllers
{
    public class HomeController : Controller
    {
        databasecontext db = new databasecontext();
        public ActionResult Index()
        {
            var a = db.programs.ToList();
            return View(a);
        }
        [HttpGet]
        public ActionResult create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult create(program pro)
        {
            db.programs.Add(pro);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            program student = db.programs.Find(id);
           
            return View(student);
        }
        [HttpPost]
        public ActionResult Edit(program pro)
        {
           if(ModelState.IsValid)
            {
                db.Entry(pro).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pro);
        }
        public ActionResult delete(int id)
        {
          
               var del= db.programs.SingleOrDefault(x => x.Id == id);
                db.programs.Remove(del);
                db.SaveChanges();
                return RedirectToAction("Index");
          
        }
      
    }
}