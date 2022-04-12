using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class Default1Controller : Controller
    {
        // GET: Default1
        employeeEntities db;
        public Default1Controller()
        {
            db = new employeeEntities();
        }
        // GET: Default
        public ActionResult Index1(string search,DateTime? startdate, DateTime? enddate)
        {
            //List<employee_salary_detail> data = db.employee_salary_detail.ToList();
            //return View(data);
            var data = db.employee_salary_detail.ToList();
            if(startdate != null && enddate != null)
            {
                data= data.Where(x=> x.paid_date >=startdate && x.paid_date <= enddate).ToList();

            }
            return View(data);
        }

        public ActionResult Create()
        {
            var empList = db.emps.ToList();
            //for option
            //ViewBag.empsList = empsList;
            ViewBag.employeeList = new SelectList(empList, "ID", "name");
            return View();
        }
        [HttpPost]
        public ActionResult Create(employee_salary_detail employee_Salary_Detail)
        {
            db.employee_salary_detail.Add(employee_Salary_Detail);
            db.SaveChanges();
            return RedirectToAction("Index1");
        }
        public ActionResult Edit(int id)
        {
            List<emp> Emplist = db.emps.ToList();
            ViewBag.employeeList = new SelectList(Emplist, "ID", "name");
            employee_salary_detail employee1 = db.employee_salary_detail.Find(id);
            return View(employee1);
        }
        public ActionResult updateData(employee_salary_detail employee_Salary_Detail)
        {
            db.Entry(employee_Salary_Detail).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("index1");
        }

        public ActionResult Delete(int id)
        {
            employee_salary_detail data = db.employee_salary_detail.Find(id);
            db.employee_salary_detail.Remove(data);
            db.SaveChanges();
            return RedirectToAction("index1");
        }
    }
}