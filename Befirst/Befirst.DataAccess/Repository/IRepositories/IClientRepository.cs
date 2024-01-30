using Befirst.DataAccess.Models;

namespace Befirst.DataAccess.Repository.IRepositories
{
    public interface IClientRepository
    {
        Task<int> AddClientAsync(Client client);

        Task<int> UpdateClientAsync(Client client);

        Task<int> DeleteClientAsync(Client client);

        Task<Client> GetClientByIdAsync(int id);

        Task<List<Client>> GetAllClientsAsync(string? searchWord);
    }
}