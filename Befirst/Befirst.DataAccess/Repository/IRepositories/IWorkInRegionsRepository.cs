using Befirst.DataAccess.Models;

namespace Befirst.DataAccess.Repository.IRepositories
{
    public interface IWorkInRegionsRepository
    {
        Task<int> AddWorkInRegionsAsync(WorkInRegions workInRegions);

        Task<int> UpdateWorkInRegionsAsync(WorkInRegions workInRegions);

        Task<int> DeleteWorkInRegionsAsync(WorkInRegions workInRegions);

        Task<WorkInRegions> GetWorkInRegionsByIdAsync(int id);

        Task<List<WorkInRegions>> GetAllWorksInRegionsAsync(string? searchWord);
    }
}