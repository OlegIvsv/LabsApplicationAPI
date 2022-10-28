
using LabsApplication.DTOModels;
using LabsApplication.UnitOfWork.EF.Models;

namespace LabsApplicationAPI.Interfaces
{
    public interface IProductService
    {
        ProductDTO GetProduct(int id);

        void AddProduct(ProductDTO product);

        IList<ProductDTO> GetAll();

        void DeleteProduct(ProductDTO product);

        void DeleteProduct(int id);

        void UpdateProduct(ProductDTO product);
    }
}
