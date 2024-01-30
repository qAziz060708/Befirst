using AutoMapper;
using FluentValidation;
using Befirst.BusinessLogic.DTOs.RequestDTO;
using Befirst.BusinessLogic.DTOs.ResponseDTO;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Befirst.BusinessLogic.Service.IServices;
using Befirst.BusinessLogic.Service.Services;

namespace Befirst.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class WorkInRegionsController : ControllerBase
    {
        private readonly IWorkInRegionsService _workInRegionsService;
        private readonly IValidator<WorkInRegionsRequestDTO> _validator;

        public WorkInRegionsController(IWorkInRegionsService workInRegionsService, IValidator<WorkInRegionsRequestDTO> validator)
        {
            _workInRegionsService = workInRegionsService;
            _validator = validator;
        }

        [HttpPost]
        public async Task<ActionResult<int>> AddWorkInRegionsAsync(WorkInRegionsRequestDTO workInRegionsRequestDTO)
        {
            try
            {
                ValidationResult validationResult = await _validator.ValidateAsync(workInRegionsRequestDTO);
                if (validationResult.IsValid)
                {
                    return await _workInRegionsService.AddWorkInRegionsAsync(workInRegionsRequestDTO);
                }
                else
                {
                    throw new Exception("You entered the values incorrectly or incompletely, please try to enter them all correctly and completely again.");
                }
            }
            catch (AutoMapperMappingException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }

        [HttpGet("Id")]
        public async Task<ActionResult<WorkInRegionsResponseDTO>> GetWorkInRegionsByIdAsync(int id)
        {
            try
            {
                return await _workInRegionsService.GetWorkInRegionsByIdAsync(id);
            }
            catch (AutoMapperMappingException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("All")]
        public async Task<ActionResult<List<WorkInRegionsResponseDTO>>> GetAllWorksInRegionsAsync(string? searchWord)
        {
            try
            {
                return await _workInRegionsService.GetAllWorksInRegionsAsync(searchWord);
            }
            catch (AutoMapperMappingException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("Id")]
        public async Task<ActionResult<int>> UpdateWorkInRegionsAsync(WorkInRegionsRequestDTO workInRegionsRequestDTO, int id)
        {
            try
            {
                ValidationResult validationResult = await _validator.ValidateAsync(workInRegionsRequestDTO);
                if (validationResult.IsValid)
                {
                    return await _workInRegionsService.UpdateWorkInRegionsAsync(workInRegionsRequestDTO, id);
                }
                else
                {
                    throw new Exception("WorkInRegions for update is not available.");
                }
            }
            catch (AutoMapperMappingException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }

        [HttpDelete("Id")]
        public async Task<ActionResult<int>> DeleteClientAsync(int id)
        {
            try
            {
                return await _workInRegionsService.DeleteWorkInRegionsAsync(id);
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
    }
}