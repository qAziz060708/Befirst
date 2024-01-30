using Befirst.BusinessLogic.DTOs.RequestDTO;
using Befirst.BusinessLogic.DTOs.ResponseDTO;

namespace Befirst.BusinessLogic.Service.IServices
{
    public interface IWorkInRegionsService
    {
        Task<int> AddWorkInRegionsAsync(WorkInRegionsRequestDTO workInRegionsRequestDTO);

        Task<int> UpdateWorkInRegionsAsync(WorkInRegionsRequestDTO workInRegionsRequestDTO, int id);

        Task<int> DeleteWorkInRegionsAsync(int id);

        Task<WorkInRegionsResponseDTO> GetWorkInRegionsByIdAsync(int id);

        Task<List<WorkInRegionsResponseDTO>> GetAllWorksInRegionsAsync(string? searchWord);
    }
}