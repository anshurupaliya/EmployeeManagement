using EmployeeManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Service.Abstraction
{
    public interface IEmployeeService
    {
        public List<Employee> GetAllEmployees();
        public Task<Employee> AddEmployee(Employee employee);
        public Task<bool> DeleteEmployee(Guid id);
        public Task<Employee> UpdateEmployee(Employee employee);
    }
}
