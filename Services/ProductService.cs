using LabsApplication.DTOModels;
using LabsApplication.UnitOfWork.EF.Models;
using LabsApplication.UnitOfWork.Interfaces;
using LabsApplication.UnitOfWork.Repositories;
using LabsApplicationAPI.Interfaces;

namespace LabsApplicationAPI.Services
{

    public class ProductService : IProductService
    {
        private IUnitOfWork unitOfWork;

        public ProductService(IUnitOfWork uof)
        {
            this.unitOfWork = uof;
        }


        public void AddProduct(ProductDTO product)
        {
            unitOfWork.Products.Insert(product);
        }

        public void DeleteProduct(ProductDTO product)
        {
            unitOfWork.Products.Delete(product);
        }

        public void DeleteProduct(int id)
        {
            unitOfWork.Products.Delete(id);
        }

        public void UpdateProduct(ProductDTO product)
        {
            unitOfWork.Products.Update(product);
        }

        public ProductDTO GetProduct(int id)
        {
            return unitOfWork.Products.Get(id);
        }

        public IList<ProductDTO> GetAll()
        {
            return unitOfWork.Products.List();
        }
    }
}
