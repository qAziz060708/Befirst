using AutoMapper;
using Befirst.BusinessLogic.DTOs.RequestDTO;
using Befirst.BusinessLogic.DTOs.ResponseDTO;
using Befirst.DataAccess.Models;

namespace Befirst.BusinessLogic.DTOs.AutoMapper
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            // ClientAutoMapper
            CreateMap<ClientRequestDTO, Client>();
            CreateMap<Client, ClientResponseDTO>()
                .ForMember(clientResponseDTO => clientResponseDTO.ClientFullName,
                opt => opt.MapFrom(client => $"{client.ClientFirstName} {client.ClientLastName}"));

            // WorkOnRegionsAutoMapper
            CreateMap<WorkInRegionsRequestDTO, WorkInRegions>();
            CreateMap<WorkInRegions, WorkInRegionsResponseDTO>();
        }
    }
}