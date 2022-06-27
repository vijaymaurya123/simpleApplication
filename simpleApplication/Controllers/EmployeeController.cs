using simpleApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace simpleApplication.Controllers
{
    public class EmployeeController : Controller
    {
        databasecontext db = new databasecontext();
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult List()
        {
            return Json(db.programs.ToList(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Add(program user)
        {
            db.programs.Add(user);
            db.SaveChanges();
            return Json(JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetbyID(int Id)
        {
            return Json(db.programs.FirstOrDefault(x => x.Id == Id), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Update(program obj)
        {
            var data = db.programs.FirstOrDefault(x => x.Id == obj.Id);
            if (data != null)
            {
                data.Name = obj.Name;              
               data.Age = obj.Age;
                data.City = obj.City;
                db.SaveChanges();
            }
            return Json(JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(int ID)
        {
            var data = db.programs.FirstOrDefault(x => x.Id == ID);
            db.programs.Remove(data);
            db.SaveChanges();
            return Json(JsonRequestBehavior.AllowGet);
        }
    }
}