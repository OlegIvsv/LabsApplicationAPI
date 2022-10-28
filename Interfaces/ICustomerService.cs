using LabsApplication.DTOModels;
using LabsApplication.UnitOfWork.EF.Models;

namespace LabsApplicationAPI.Interfaces
{
    public interface ICustomerService
    {
        CustomerDTO GetCustomer(int id);

        IList<CustomerDTO> GetAll();

        void AddCustomer(CustomerDTO customer);

        void DeleteCustomer(CustomerDTO customer);

        void DeleteCustomer(int id);

        void UpdateCustomer(CustomerDTO customer);
    }
}
