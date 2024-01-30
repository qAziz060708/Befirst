using Befirst.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Befirst.DataAccess.DbConnection;
using Befirst.DataAccess.Repository.IRepositories;

namespace Befirst.DataAccess.Repository.Repositories
{
    public class ClientRepository : IClientRepository
    {
        public readonly BefirstDbContext _clientDbContext;

        public ClientRepository(BefirstDbContext clientDbContext)
        {
            _clientDbContext = clientDbContext;
        }

        public async Task<int> AddClientAsync(Client client)
        {
            try
            {
                _clientDbContext.Clients.Add(client);
                await _clientDbContext.SaveChangesAsync();
                return client.ClientId;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Connection between database is failed");
            }
            catch (Exception ex)
            {
                throw new Exception("Operation was failed when it was adding changes");
            }
        }

        public async Task<int> DeleteClientAsync(Client client)
        {
            try
            {
                _clientDbContext.Clients.Remove(client);
                await _clientDbContext.SaveChangesAsync();
                return client.ClientId;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Connection between database is failed");
            }
            catch (Exception ex)
            {
                throw new Exception("Operation was failed when it was deleting changes");
            }
        }

        public async Task<List<Client>> GetAllClientsAsync(string? searchWord)
        {
            try
            {
                var allClients = await _clientDbContext.Clients
                   .ToListAsync();
                if (!string.IsNullOrEmpty(searchWord))
                {
                    allClients = allClients.Where(n => n.ClientFirstName.Contains(searchWord) || n.ClientLastName.Contains(searchWord)).ToList();
                }
                return allClients;
            }
            catch (InvalidOperationException ex)
            {
                throw new Exception("Operation was failed when it was giving the info");
            }
            catch (Exception ex)
            {
                throw new Exception("Operation was failed when it was giving clients information");
            }
        }

        public async Task<Client> GetClientByIdAsync(int id)
        {
            try
            {
                return await _clientDbContext.Clients
                   .FirstOrDefaultAsync(u => u.ClientId == id);
            }
            catch (InvalidOperationException ex)
            {
                throw new Exception("Operation was failed when it was giving the info");
            }
            catch (Exception ex)
            {
                throw new Exception("Operation was failed when it was giving ClientById information");
            }
        }

        public async Task<int> UpdateClientAsync(Client client)
        {
            try
            {
                _clientDbContext.Clients.Update(client);
                await _clientDbContext.SaveChangesAsync();
                return client.ClientId;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Connection between database is failed");
            }
            catch (Exception ex)
            {
                throw new Exception("Operation was failed when it updating changes");
            }
        }
    }
}