using AutoMapper;
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

            sc.AddSingleton<IAppDatabase, AdoDatabase>(
                p => new(p.GetService<IConfiguration>()["ConnectionStrings:MainConnection"]));

            sc.AddSingleton<IProductService, ProductService>(
                p => new(p.GetService<IAppDatabase>()!, p.GetService<IMapper>()!));

            sc.AddSingleton<ICustomerService, CustomerService>(
                p => new(p.GetService<IAppDatabase>()!, p.GetService<IMapper>()!));

            sc.AddSingleton<IOrderService, OrderService>(
                p => new(p.GetService<IAppDatabase>()!, p.GetService<IMapper>()!));

            sc.AddSingleton<IProducerService, ProducerService>(
                p => new(p.GetService<IAppDatabase>()!, p.GetService<IMapper>()!));

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
