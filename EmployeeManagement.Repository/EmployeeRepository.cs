using EmployeeManagement.Model;
using EmployeeManagement.Repository.Abstraction;
using Microsoft.AspNetCore.Http;
using Practical123.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public EmployeeRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Employee> AddEmployee(Employee e)
        {
            e.CreatedBy = _httpContextAccessor.HttpContext.User.Identity.Name;
            e.CreatedAt = DateTime.Now;
            e.IsDeleted = false;
            await _context.Employees.AddAsync(e);
            await _context.SaveChangesAsync();
            return e;
        }

        public async Task<bool> DeleteEmployee(Employee e)
        {
            Employee data = _context.Employees.FirstOrDefault(c1 => c1.Id == e.Id);
            data.IsDeleted = true;
            data.DeletedAt = DateTime.Now;
            data.IsDeletedBy = _httpContextAccessor.HttpContext.User.Identity.Name;
            var emp = _context.MeetingAttendees.Where(c => c.SelectedEmployeeId == e.Id);
            foreach(var emp1 in emp)
            {
                emp1.IsDeleted = true;
            }
            await _context.SaveChangesAsync();
            return true;
        }

        public List<Employee> GetAllEmployees()
        {
            return _context.Employees.Where(c => c.IsDeleted == false).ToList();
        }

        public async Task<Employee> UpdateEmployee(Employee e)
        {
            var Data = GetAllEmployees().FirstOrDefault(c1 => c1.Id == e.Id);
            Data.FirstName = e.FirstName;
            Data.LastName=e.LastName;
            Data.Address = e.Address;
            Data.DateOfJoining = e.DateOfJoining;
            Data.DepartmentId = e.DepartmentId;
            Data.Email = e.Email;
            Data.UpdatedAt = DateTime.Now;
            Data.UpdatedBy = _httpContextAccessor.HttpContext.User.Identity.Name;
            await _context.SaveChangesAsync();
            return e;
        }
    }
}
