using EmployeeManagement.Repository.Abstraction;
using Microsoft.AspNetCore.Http;
using Microsoft.Identity.Client;
using Practical123.Models;


namespace EmployeeManagement.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public DepartmentRepository(ApplicationDbContext context,IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<Department> AddDepartment(Department d)
        {
            d.IsDeleted = false;
            d.CreatedAt = DateTime.Now;
            d.CreatedBy= _httpContextAccessor.HttpContext.User.Identity.Name;
            await _context.Departments.AddAsync(d);
            await _context.SaveChangesAsync();
            return d;
        }

        public async Task<bool> DeleteDepartment(Department d)
        {
            Department data=_context.Departments.FirstOrDefault(c1 => c1.Id == d.Id);
            data.IsDeleted = true;
            data.DeletedAt = DateTime.Now;
            data.IsDeletedBy = _httpContextAccessor.HttpContext.User.Identity.Name;
            await _context.SaveChangesAsync();
            return true;
        }

        public List<Department> GetAllDepartment()
        {
            return _context.Departments.Where(c => c.IsDeleted == false).ToList();
        }

        public async Task<Department> UpdateDepartment(Department d)
        {
            var Data = GetAllDepartment().FirstOrDefault(c1 => c1.Id == d.Id);
            Data.Name = d.Name;
            Data.UpdatedBy = _httpContextAccessor.HttpContext.User.Identity.Name;
            Data.UpdatedAt = DateTime.Now;
            await _context.SaveChangesAsync();
            return d;
        }
    }
}
