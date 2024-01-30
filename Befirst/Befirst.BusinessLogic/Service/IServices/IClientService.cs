using Befirst.BusinessLogic.DTOs.RequestDTO;
using Befirst.BusinessLogic.DTOs.ResponseDTO;

namespace Befirst.BusinessLogic.Service.IServices
{
    public interface IClientService
    {
        Task<int> AddClientAsync(ClientRequestDTO clientRequestDTO);

        Task<int> UpdateClientAsync(ClientRequestDTO clientRequestDTO, int id);

        Task<int> DeleteClientAsync(int id);

        Task<ClientResponseDTO> GetClientByIdAsync(int id);

        Task<List<ClientResponseDTO>> GetAllClientsAsync(string? searchWord);
    }
}