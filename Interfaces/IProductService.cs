
using LabsApplication.DTOModels;
using LabsApplicationAPI.Models;

namespace LabsApplicationAPI.Interfaces
{
    public interface IProductService
    {
        Product GetProduct(int id);

        void AddProduct(Product product);

        IList<Product> GetAll();

        void DeleteProduct(Product product);

        void DeleteProduct(int id);

        void UpdateProduct(Product product);

        IList<Product> GetProductsByPriceRange(int minPrice, int maxPrice);
    }
}
