using AutoMapper;
using LabsApplication.DTOModels;
using LabsApplication.UnitOfWork.EF.Models;
using LabsApplicationAPI.ViewModels;

namespace LabsApplicationAPI.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductDTO, ProductVM>();
            CreateMap<ProductVM, ProductDTO>();

            CreateMap<OrderDTO, OrderVM>();
            CreateMap<OrderVM, OrderDTO>();

            CreateMap<ProducerDTO, ProductVM>();
            CreateMap<ProductVM, ProducerDTO>();

            CreateMap<CustomerDTO, CustomerVM>();
            CreateMap<CustomerVM, CustomerDTO>();
        }
    }
}
