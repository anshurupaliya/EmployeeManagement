using Practical123.Models;

namespace EmployeeManagement.Service.Abstraction
{
    public interface IClientService
    {
        public List<Client> GetAllClients();
        public Task<Client> AddClient(Client c);
        public Task<bool> DeleteClient(Guid id);
        public Task<Client> UpdateClient(Client c);
    }
}
