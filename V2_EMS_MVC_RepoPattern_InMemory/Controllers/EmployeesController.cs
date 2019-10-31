using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using V2_EMS_MVC_RepoPattern_InMemory.Data;
using V2_EMS_MVC_RepoPattern_InMemory.Models;

namespace V2_EMS_MVC_RepoPattern_InMemory.Controllers
{
    public class EmployeesController : Controller
    {
        IRepository _repository = null;
        public EmployeesController(IRepository repository)
        {
            _repository = repository;
        }
        // GET: Employees
        public ActionResult Index()
        {
            return View(_repository.GetEmployees());
        }

        // GET: Employees/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repository.Add(employee);
                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int id)
        {
            var emp = _repository.GetById(id);
            if (emp == null)
            {
                return NotFound();
            }
            return View(emp);
        }

        // POST: Employees/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Employee employee)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                if (id != employee.Id)
                {
                    return BadRequest();
                }
                bool result = _repository.Edit(employee);
                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return Content("<script>alert('Failed');</script>");
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int id)
        {
            var emp = _repository.GetById(id);
            if (emp == null)
            {
                return NotFound();
            }
            return View(emp);
        }

        // POST: Employees/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int? id)
        {
            try
            {
                var emp = _repository.GetById(id.GetValueOrDefault());
                if (emp == null)
                {
                    return NotFound();
                }
                bool result = _repository.Delete(emp);

                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return Content("<script language='javascript' type='text/javascript'>alert('Failed');</script>");
                }
            }
            catch
            {
                return View();
            }
        }

        public IActionResult SearchByGender()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SearchByGender(Gender gender)
        {
            var employees = _repository.GetByGender(gender);
            if (employees.Count() == 0)
            {
                ViewBag.Message = "No employees found";
                return View();
            }

            return View(employees);
        }

        public IActionResult SearchByJobTitle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SearchByJobTitle(JobTitle jobTitle)
        {
            var emp = _repository.GetByJobTitle(jobTitle);
            if (emp.Count() == 0)
            {
                ViewBag.Message = "No employees found";
                return View();
            }

            return View(emp);
        }
    }
}