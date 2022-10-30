﻿using AutoMapper;
using LabsApplication.AdoNet;
using LabsApplication.UnitOfWork.Interfaces;
using LabsApplicationAPI.Interfaces;
using LabsApplicationAPI.Mapping;

namespace LabsApplicationAPI.Services
{
    public static class AppConfigServicesExtensions
    {
        public static IServiceCollection AddUserDefinedDependencies(this IServiceCollection sc)
        {
            string connectionString = "Server=DESKTOP-9CVRRHV;Database=LabsApplicationDb;Trusted_Connection=True;Encrypt=False;";
            sc.AddSingleton<IUnitOfWork, AdoUnitOfWork>(p => new(connectionString));

            sc.AddSingleton<IProductService, ProductService>(
                p => new(p.GetService<IUnitOfWork>()!, p.GetService<IMapper>()!));

            sc.AddSingleton<ICustomerService, CustomerService>(
                p => new(p.GetService<IUnitOfWork>()!, p.GetService<IMapper>()!));

            sc.AddSingleton<IOrderService, OrderService>(
                p => new(p.GetService<IUnitOfWork>()!, p.GetService<IMapper>()!));

            sc.AddSingleton<IProducerService, ProducerService>(
                p => new(p.GetService<IUnitOfWork>()!, p.GetService<IMapper>()!));

            return sc;
        }

        public static IServiceCollection AddStandardDependencies(this IServiceCollection sc)
        {
            sc.AddControllers();

            sc.AddEndpointsApiExplorer();

            sc.AddSwaggerGen();

            sc.AddAutoMapper(typeof(MappingProfile));

            return sc;
        }
    }
}