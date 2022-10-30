using LabsApplicationAPI.Interfaces;
using LabsApplication.UnitOfWork.Interfaces;
using LabsApplication.DTOModels;
using AutoMapper;
using LabsApplicationAPI.Models;


namespace LabsApplicationAPI.Services
{
    public class CustomerService : ICustomerService
    {
        private IUnitOfWork unitOfWork;
        private IMapper mapper; 

        public CustomerService(IUnitOfWork uof, IMapper mapper)
        {
            this.unitOfWork = uof;
            this.mapper = mapper;
        }

        public void AddCustomer(Customer customer)
        {
            var data = mapper.Map<Customer, CustomerData>(customer);
            unitOfWork.Customers.Insert(data);
        }

        public void DeleteCustomer(Customer customer)
        {
            var data = mapper.Map<Customer, CustomerData>(customer);
            unitOfWork.Customers.Delete(data);
        }

        public void DeleteCustomer(int id)
        {
            unitOfWork.Customers.Delete(id);
        }

        public void UpdateCustomer(Customer customer)
        {
            var data = mapper.Map<Customer, CustomerData>(customer);
            unitOfWork.Customers.Update(data);
        }

        public Customer GetCustomer(int id)
        {
            var data = unitOfWork.Customers.Get(id);
            return mapper.Map<CustomerData, Customer>(data);
        }

        public IList<Customer> GetAll()
        {
            var data = unitOfWork.Customers.List();
            return data.Select( d => mapper.Map<CustomerData, Customer>(d))
                .ToList();
        }
    }
}
