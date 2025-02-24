using Practical123.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Repository.Abstraction
{
    public interface IDepartmentRepository
    {
        public List<Department> GetAllDepartment();
        public Task<Department> AddDepartment(Department d);
        public Task<bool> DeleteDepartment(Department d);
        public Task<Department> UpdateDepartment(Department d);
    }
}
