using AutoMapper;
using Befirst.BusinessLogic.DTOs.RequestDTO;
using Befirst.BusinessLogic.DTOs.ResponseDTO;
using Befirst.BusinessLogic.Service.IServices;
using Befirst.DataAccess.Models;
using Befirst.DataAccess.Repository.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Befirst.BusinessLogic.Service.Services
{
    public class WorkInRegionsService : IWorkInRegionsService
    {
        private readonly IWorkInRegionsRepository _workInRegionsRepository;
        private readonly IMapper _mapper;

        public WorkInRegionsService(IWorkInRegionsRepository workInRegionsRepository, IMapper mapper)
        {
            _workInRegionsRepository = workInRegionsRepository;
            _mapper = mapper;
        }

        public async Task<int> AddWorkInRegionsAsync(WorkInRegionsRequestDTO workInRegionsRequestDTO)
        {
            try
            {
                return await _workInRegionsRepository.AddWorkInRegionsAsync(_mapper.Map<WorkInRegions>(workInRegionsRequestDTO));
            }
            catch (AutoMapperMappingException ex)
            {
                throw new Exception("Mapping failed");
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<int> DeleteWorkInRegionsAsync(int id)
        {
            try
            {
                var workInRegionsResult = await _workInRegionsRepository.GetWorkInRegionsByIdAsync(id);
                if (workInRegionsResult is not null)
                {
                    return await _workInRegionsRepository.DeleteWorkInRegionsAsync(workInRegionsResult);
                }
                else
                {
                    throw new Exception("Object cannot be deleted");
                }
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Operation was failed when it was deleting changes");
            }
        }

        public async Task<List<WorkInRegionsResponseDTO>> GetAllWorksInRegionsAsync(string? searchWord)
        {
            try
            {
                return _mapper.Map<List<WorkInRegionsResponseDTO>>(await _workInRegionsRepository.GetAllWorksInRegionsAsync(searchWord));
            }
            catch (AutoMapperMappingException ex)
            {
                throw new Exception("Mapping failed");
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<WorkInRegionsResponseDTO> GetWorkInRegionsByIdAsync(int id)
        {
            try
            {
                return _mapper.Map<WorkInRegionsResponseDTO>(await _workInRegionsRepository.GetWorkInRegionsByIdAsync(id));
            }
            catch (AutoMapperMappingException ex)
            {
                throw new Exception("Mapping failed");
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<int> UpdateWorkInRegionsAsync(WorkInRegionsRequestDTO workInRegionsRequestDTO, int id)
        {
            try
            {
                var workInRegionsResult = await _workInRegionsRepository.GetWorkInRegionsByIdAsync(id);
                if (workInRegionsResult is not null)
                {
                    workInRegionsResult = _mapper.Map<WorkInRegions>(workInRegionsRequestDTO);
                    workInRegionsResult.WorkInRegionsId = id;
                    return await _workInRegionsRepository.UpdateWorkInRegionsAsync(workInRegionsResult);
                }
                else
                {
                    throw new Exception("Object cannot be updated.");
                }
            }
            catch (AutoMapperMappingException ex)
            {
                throw new Exception("Mapping failed.");
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Operation was failed when it was updating changes.");
            }
        }
    }
}