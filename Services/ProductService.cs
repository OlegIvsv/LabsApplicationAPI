using AutoMapper;
using LabsApplication.DTOModels;
using LabsApplicationAPI.Models;
using LabsApplication.UnitOfWork.Interfaces;
using LabsApplication.UnitOfWork.Repositories;
using LabsApplicationAPI.Interfaces;

namespace LabsApplicationAPI.Services
{

    public class ProductService : IProductService
    {
        private IUnitOfWork unitOfWork;
        private IMapper mapper;

        public ProductService(IUnitOfWork uof, IMapper mapper)
        {
            this.unitOfWork = uof;
            this.mapper = mapper;
        }


        public void AddProduct(Product product)
        {
            var data = mapper.Map<Product, ProductData>(product);
            unitOfWork.Products.Insert(data);
        }

        public void DeleteProduct(Product product)
        {
            var data = mapper.Map<Product, ProductData>(product);
            unitOfWork.Products.Delete(data);
        }

        public void DeleteProduct(int id)
        {
            unitOfWork.Products.Delete(id);
        }

        public void UpdateProduct(Product product)
        {
            var data = mapper.Map<Product, ProductData>(product);
            unitOfWork.Products.Update(data);
        }

        public Product GetProduct(int id)
        {
            var data = unitOfWork.Products.Get(id);
            return mapper.Map<ProductData, Product>(data);
        }

        public IList<Product> GetAll()
        {
            var data = unitOfWork.Products.List();
            return data.Select(d => mapper.Map<ProductData, Product>(d))
                .ToList();
        }
    }
}
