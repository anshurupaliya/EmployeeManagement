using Practical123.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Repository.Abstraction
{
    public interface IClientRepository
    {
        public List<Client> GetAllClients();
        public Task<Client> AddClient(Client c);
        public Task<bool> DeleteClient(Client c);
        Task<Client> UpdateClient(Client c);

    }
}
