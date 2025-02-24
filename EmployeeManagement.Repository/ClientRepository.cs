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
    public class ClientRepository:IClientRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ClientRepository(ApplicationDbContext context,IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Client> AddClient(Client c)
        {
            c.CreatedBy = _httpContextAccessor.HttpContext.User.Identity.Name;
            c.CreatedAt = DateTime.Now;
            c.IsDeleted = false;
            await _context.Clients.AddAsync(c);
            await _context.SaveChangesAsync();
            return c;
        }

        public async Task<bool> DeleteClient(Client c)
        {
            Client data= _context.Clients.FirstOrDefault(c1 => c1.Id == c.Id);
            data.IsDeleted = true;
            data.DeletedAt = DateTime.Now;
            data.IsDeletedBy = _httpContextAccessor.HttpContext.User.Identity.Name;
            await _context.SaveChangesAsync();
            return true;
        }

        public List<Client> GetAllClients()
        {
            return _context.Clients.Where(c=>c.IsDeleted==false).ToList();
        }

        public async Task<Client> UpdateClient(Client c)
        {
            var Data = GetAllClients().FirstOrDefault(c1 => c1.Id == c.Id);
            Data.Name = c.Name;
            Data.Email = c.Email;
            Data.Phone = c.Phone;
            Data.Address = c.Address;
            Data.UpdatedAt = DateTime.Now;
            Data.UpdatedBy = _httpContextAccessor.HttpContext.User.Identity.Name;
            await _context.SaveChangesAsync();
            return c;
        }
    }
}
