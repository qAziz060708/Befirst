using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Befirst.BusinessLogic.DTOs.RequestDTO;
using Befirst.BusinessLogic.Service.IServices;
using Befirst.BusinessLogic.Service.Services;
using Befirst.DataAccess.Repository.IRepositories;
using Befirst.DataAccess.Repository.Repositories;

namespace Befirst.BusinessLogic.ServiceExtentions
{
    public static class ServiceExtentions
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Mvc
            services.AddMvc();

            // Validation
            services.AddScoped<IValidator<ClientRequestDTO>, ClientRequestDTOValidator>();
            services.AddScoped<IValidator<WorkInRegionsRequestDTO>, WorkInRegionsRequestDTOValidator>();
            services.AddScoped<IValidator<PaymentRequestDTO>, PaymentRequestDTOValidator>();

            // AutoMapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // Repositories
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IWorkInRegionsRepository, WorkInRegionsRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();

            // Services
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IWorkInRegionsService, WorkInRegionsService>();
            services.AddScoped<IPaymentService, PaymentService>();
        }
    }
}