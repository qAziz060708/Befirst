using Befirst.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Befirst.DataAccess.DbConnection;
using Befirst.DataAccess.Repository.IRepositories;

namespace Befirst.DataAccess.Repository.Repositories
{
    public class WorkInRegionsRepository : IWorkInRegionsRepository
    {
        private readonly BefirstDbContext _workInRegionsDbContext;

        public WorkInRegionsRepository(BefirstDbContext workInRegionsDbContext)
        {
            _workInRegionsDbContext = workInRegionsDbContext;
        }

        public async Task<int> AddWorkInRegionsAsync(WorkInRegions workInRegions)
        {
            try
            {
                _workInRegionsDbContext.WorksInRegions.Add(workInRegions);
                await _workInRegionsDbContext.SaveChangesAsync();
                return workInRegions.WorkInRegionsId;
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

        public async Task<int> DeleteWorkInRegionsAsync(WorkInRegions workInRegions)
        {
            try
            {
                _workInRegionsDbContext.WorksInRegions.Remove(workInRegions);
                await _workInRegionsDbContext.SaveChangesAsync();
                return workInRegions.WorkInRegionsId;
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

        public async Task<List<WorkInRegions>> GetAllWorksInRegionsAsync(string? searchWord)
        {
            try
            {
                var allWorksInRegions = await _workInRegionsDbContext.WorksInRegions
                   .ToListAsync();
                if (!string.IsNullOrEmpty(searchWord))
                {
                    allWorksInRegions = allWorksInRegions.Where(n => n.Region.Contains(searchWord) || n.School.Contains(searchWord) || n.Kindergarten.Contains(searchWord)).ToList();
                }
                return allWorksInRegions;
            }
            catch (InvalidOperationException ex)
            {
                throw new Exception("Operation was failed when it was giving the info");
            }
            catch (Exception ex)
            {
                throw new Exception("Operation was failed when it was giving WorksInRegions information");
            }
        }

        public async Task<WorkInRegions> GetWorkInRegionsByIdAsync(int id)
        {
            try
            {
                return await _workInRegionsDbContext.WorksInRegions
                   .FirstOrDefaultAsync(u => u.WorkInRegionsId == id);
            }
            catch (InvalidOperationException ex)
            {
                throw new Exception("Operation was failed when it was giving the info");
            }
            catch (Exception ex)
            {
                throw new Exception("Operation was failed when it was giving WorkInRegionsById information");
            }
        }

        public async Task<int> UpdateWorkInRegionsAsync(WorkInRegions workInRegions)
        {
            try
            {
                _workInRegionsDbContext.WorksInRegions.Update(workInRegions);
                await _workInRegionsDbContext.SaveChangesAsync();
                return workInRegions.WorkInRegionsId;
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