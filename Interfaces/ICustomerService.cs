using LabsApplication.DTOModels;
using LabsApplicationAPI.Models;

namespace LabsApplicationAPI.Interfaces
{
    public interface ICustomerService
    {
        Customer GetCustomer(int id);

        IList<Customer> GetAll();

        void AddCustomer(Customer customer);

        void DeleteCustomer(Customer customer);

        void DeleteCustomer(int id);

        void UpdateCustomer(Customer customer);
    }
}
