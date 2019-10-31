using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using V1_Ems_.NETCore_MVC_InMemory.Models;

namespace V1_Ems_.NETCore_MVC_InMemory.Controllers
{
    public class EmployeesController : Controller
    {
        static List<Employee> employees = new List<Employee>
            {
                new Employee{Id=1, FirstName="Param", LastName="Parmar",
                DateOfBirth = new DateTime(1990,1,1),
                DateOfJoining = new DateTime(2016,1,1), Phone=9888776690,
                Email = "param@gmail.com", Gender=Gender.Male,
                    JobTitle=JobTitle.Manager},
                new Employee{Id=2, FirstName="Shweta", LastName="Modi",
                DateOfBirth = new DateTime(1991,1,1),
                DateOfJoining = new DateTime(2017,1,1), Phone=876558909,
                Email = "shweta@gmail.com", Gender=Gender.Female,
                    JobTitle=JobTitle.Analyst}
            };
        public IActionResult Index()
        {
            return View(employees);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                employees.Add(employee);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public IActionResult Edit(int id)
        {
            var employee = employees.Find(e => e.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }
        [HttpPost]
        public IActionResult Edit(int id, Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return View(employee);
            }
            if (id != employee.Id)
            {
                return BadRequest();
            }

            var emp = employees.Find(e => e.Id == id);
            if (emp == null)
            {
                return NotFound();
            }
            //update
            emp.FirstName = employee.FirstName;
            emp.LastName = employee.LastName;
            emp.DateOfBirth = employee.DateOfBirth;
            emp.DateOfJoining = employee.DateOfJoining;
            emp.Email = employee.Email;
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            var employee = employees.Find(e => e.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        public IActionResult Delete(int? id)
        {
            var employee = employees.Find(e => e.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var employee = employees.Find(e => e.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            employees.Remove(employee);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult GetById()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetById(int id)
        {
            var employee = employees.Find(e => e.Id == id);
            if (employee == null)
            {
                //return NotFound();
                ViewBag.Message = "No employee found";
                return View();
            }

            return View(employee);
        }

        public IActionResult SearchByGender()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SearchByGender(Gender gender)
        {
            var employees = EmployeesController.employees
                .FindAll(e => e.Gender == gender);
            if (employees.Count == 0)
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
            var emp = EmployeesController.employees
                .FindAll(e => e.JobTitle == jobTitle);
            if (emp.Count == 0)
            {
                ViewBag.Message = "No employees found";
                return View();
            }

            return View(emp);
        }
    }
}