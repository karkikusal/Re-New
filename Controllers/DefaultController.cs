using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class DefaultController : Controller
    {
        employeeEntities db;
        public DefaultController()
        {
            db = new employeeEntities();
        }
        // GET: Default
        public ActionResult Index()
        {
            List<emp> data = db.emps.ToList();
            return View(data);


        }
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult SaveData(emp emp)
        {
            db.emps.Add(emp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UpdateData(emp emp)
        {
            db.Entry(emp).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            emp data = db.emps.Find(id);//find data using primary key
            //emp data=db.emp.First0rDefault(x=> x.id== id);
            return View(data);
        }
        public ActionResult Delete(int id)
        {
            emp data = db.emps.Find(id);
            db.emps.Remove(data);
            db.SaveChanges();
            return RedirectToAction("index");
        }
    }
}