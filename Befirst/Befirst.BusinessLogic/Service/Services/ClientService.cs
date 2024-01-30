using AutoMapper;
using Befirst.BusinessLogic.DTOs.RequestDTO;
using Befirst.BusinessLogic.DTOs.ResponseDTO;
using Befirst.BusinessLogic.Service.IServices;
using Befirst.DataAccess.Models;
using Befirst.DataAccess.Repository.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Befirst.BusinessLogic.Service.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;

        public ClientService(IClientRepository clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        public async Task<int> AddClientAsync(ClientRequestDTO clientRequestDTO)
        {
            try
            {
                return await _clientRepository.AddClientAsync(_mapper.Map<Client>(clientRequestDTO));
            }
            catch (AutoMapperMappingException ex)
            {
                throw new Exception("Mapping failed");
            }
            catch (DbUpdateException ex)
            {
                throw new Exception($"{ex.Message} , {ex.StackTrace}");
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message} , {ex.StackTrace}");
            }
        }

        public async Task<int> DeleteClientAsync(int id)
        {
            try
            {
                var clientResult = await _clientRepository.GetClientByIdAsync(id);
                if (clientResult is not null)
                {
                    return await _clientRepository.DeleteClientAsync(clientResult);
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

        public async Task<List<ClientResponseDTO>> GetAllClientsAsync(string? searchWord)
        {
            try
            {
                return _mapper.Map<List<ClientResponseDTO>>(await _clientRepository.GetAllClientsAsync(searchWord));
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
                throw new Exception($"{ex.Message} , {ex.StackTrace}");
            }
        }

        public async Task<ClientResponseDTO> GetClientByIdAsync(int id)
        {
            try
            {
                return _mapper.Map<ClientResponseDTO>(await _clientRepository.GetClientByIdAsync(id));
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
                throw new Exception($"{ex.Message} , {ex.StackTrace}");
            }
        }

        public async Task<int> UpdateClientAsync(ClientRequestDTO clientRequestDTO, int id)
        {
            try
            {
                var clientResult = await _clientRepository.GetClientByIdAsync(id);
                if (clientResult is not null)
                {
                    clientResult = _mapper.Map<Client>(clientRequestDTO);
                    clientResult.ClientId = id;
                    return await _clientRepository.UpdateClientAsync(clientResult);
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