using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using V2_EMS_MVC_RepoPattern_InMemory.Models;

namespace V2_EMS_MVC_RepoPattern_InMemory.Data
{
    public class EmployeeRepository : IRepository
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

        public bool Add(Employee employee)
        {
            try
            {
                employees.Add(employee);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(Employee employee)
        {
            try
            {
                employees.Remove(employee);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Edit(Employee employee)
        {
            try
            {
                var emp = employees.Find(e => e.Id == employee.Id);
                emp.FirstName = employee.FirstName;
                emp.LastName = employee.LastName;
                emp.DateOfBirth = employee.DateOfBirth;
                emp.DateOfJoining = employee.DateOfJoining;
                emp.Gender = employee.Gender;
                emp.JobTitle = employee.JobTitle;
                emp.Email = employee.Email;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IEnumerable<Employee> GetByGender(Gender gender)
        {
            var list = employees.FindAll(e => e.Gender == gender);
            return list;
        }

        public Employee GetById(int employeeId)
        {
            var employee = employees.Find(e => e.Id == employeeId);
            return employee;
        }

        public IEnumerable<Employee> GetByJobTitle(JobTitle jobTitle)
        {
            var list = employees.FindAll(e => e.JobTitle == jobTitle);
            return list;
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return employees;
        }
    }
}
