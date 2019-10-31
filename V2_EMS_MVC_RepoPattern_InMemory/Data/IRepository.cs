using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using V2_EMS_MVC_RepoPattern_InMemory.Models;

namespace V2_EMS_MVC_RepoPattern_InMemory.Data
{
    public interface IRepository
    {
        IEnumerable<Employee> GetEmployees();
        Employee GetById(int employeeId);
        bool Add(Employee employee);
        bool Edit(Employee employee);
        bool Delete(Employee employee);
        IEnumerable<Employee> GetByGender(Gender gender);
        IEnumerable<Employee> GetByJobTitle(JobTitle jobTitle);
    }
}
