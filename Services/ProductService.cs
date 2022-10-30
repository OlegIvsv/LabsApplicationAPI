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
        private IAppDatabase database;
        private IMapper mapper;

        public ProductService(IAppDatabase database, IMapper mapper)
        {
            this.database = database;
            this.mapper = mapper;
        }


        public void AddProduct(Product product)
        {
            var data = mapper.Map<Product, ProductData>(product);
            database.Products.Insert(data);
            database.Complete();
        }

        public void DeleteProduct(Product product)
        {
            var data = mapper.Map<Product, ProductData>(product);
            database.Products.Delete(data);
            database.Complete();
        }

        public void DeleteProduct(int id)
        {
            database.Products.Delete(id);
            database.Complete();
        }

        public void UpdateProduct(Product product)
        {
            var data = mapper.Map<Product, ProductData>(product);
            database.Products.Update(data);
            database.Complete();
        }

        public Product GetProduct(int id)
        {
            var data = database.Products.Get(id);
            return mapper.Map<ProductData, Product>(data);
        }

        public IList<Product> GetAll()
        {
            var data = database.Products.List();
            return data.Select(d => mapper.Map<ProductData, Product>(d))
                .ToList();
        }

        public IList<Product> GetProductsByPriceRange(int minPrice, int maxPrice)
        {
            var data = database.Products.List(p => p.Price >= minPrice && p.Price <= maxPrice);
            return data.Select(d => mapper.Map<ProductData, Product>(d))
                .ToList();
        }
    }
}
