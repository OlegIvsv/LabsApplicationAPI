using LabsApplicationAPI.Interfaces;
using LabsApplication.UnitOfWork.Interfaces;
using LabsApplication.UnitOfWork.EF.Models;
using LabsApplication.DTOModels;

namespace LabsApplicationAPI.Services
{
    public class CustomerService : ICustomerService
    {
        private IUnitOfWork unitOfWork;

        public CustomerService(IUnitOfWork uof)
        {
            this.unitOfWork = uof;
        }

        public void AddCustomer(CustomerDTO customer)
        {
            unitOfWork.Customers.Insert(customer);
        }

        public void DeleteCustomer(CustomerDTO customer)
        {
            unitOfWork.Customers.Delete(customer);
        }

        public void DeleteCustomer(int id)
        {
            unitOfWork.Customers.Delete(id);
        }

        public void UpdateCustomer(CustomerDTO customer)
        {
            unitOfWork.Customers.Update(customer);
        }

        public CustomerDTO GetCustomer(int id)
        {
            return unitOfWork.Customers.Get(id);
        }

        public IList<CustomerDTO> GetAll()
        {
            return unitOfWork.Customers.List();
        }
    }
}
