using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp1.Controllers
{
    public class HomeController : Controller
    {
        EMPDBEntities _context = new EMPDBEntities();
        public ActionResult Index()
        {
            var listofdata = _context.Employees.ToList();
            return View(listofdata);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee model)
        {
            _context.Employees.Add(model);
            _context.SaveChanges();
            ViewBag.Message = "Data Inserted Successfully";
            //return View();
            return RedirectToAction("index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = _context.Employees.Where(x => x.EmpID == id).FirstOrDefault();
            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(Employee model)
        {
            var data = _context.Employees.Where(x => x.EmpID == model.EmpID).FirstOrDefault();
            if (data != null)
            {
                data.FirstName = model.FirstName;
                data.LastName = model.LastName;
                data.Location = model.Location;
                data.Dept = model.Dept;
                _context.SaveChanges();
            }
            
            return RedirectToAction("index");

        }

        public ActionResult Detail(int id)
        {
            var data = _context.Employees.Where(x => x.EmpID == id).FirstOrDefault();
            return View(data);
        }

        public ActionResult Delete(int id)
        {
            var data = _context.Employees.Where(x => x.EmpID == id).FirstOrDefault();
            _context.Employees.Remove(data);
            _context.SaveChanges();
            ViewBag.Message = "Record deleted successfully";
            return RedirectToAction("index");
        }
    }
}