using EmployeeManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Repository.Abstraction
{
    public interface IEmployeeRepository
    {
        public List<Employee> GetAllEmployees();
        public Task<Employee> AddEmployee(Employee e);
        public Task<bool> DeleteEmployee(Employee e);
        public Task<Employee> UpdateEmployee(Employee e);
    }
}
