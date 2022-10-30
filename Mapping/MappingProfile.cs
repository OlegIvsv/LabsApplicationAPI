using AutoMapper;
using LabsApplication.DTOModels;
using LabsApplicationAPI.Models;
using LabsApplicationAPI.ViewModels;

namespace LabsApplicationAPI.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Busines model model to data model
            CreateMap<ProductData, Product>();
            CreateMap<Product, ProductData>();

            CreateMap<OrderData, Order>();
            CreateMap<Order, OrderData>();

            CreateMap<ProducerData, Product>();
            CreateMap<Product, ProducerData>();

            CreateMap<CustomerData, Customer>();
            CreateMap<Customer, CustomerData>();

            // View model to busines model
            CreateMap<Product, ProductVM>();
            CreateMap<ProductVM, Product>();

            CreateMap<Order, OrderVM>();
            CreateMap<OrderVM, Order>();

            CreateMap<Producer, ProducerVM>();
            CreateMap<ProducerVM, Producer>();

            CreateMap<Customer, CustomerVM>();
            CreateMap<CustomerVM, Customer>();
        }
    }
}
