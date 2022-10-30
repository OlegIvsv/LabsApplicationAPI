using LabsApplicationAPI.Interfaces;
using LabsApplication.UnitOfWork.Interfaces;
using LabsApplication.DTOModels;
using AutoMapper;
using LabsApplicationAPI.Models;


namespace LabsApplicationAPI.Services
{
    public class CustomerService : ICustomerService
    {
        private IAppDatabase database;
        private IMapper mapper; 

        public CustomerService(IAppDatabase database, IMapper mapper)
        {
            this.database = database;
            this.mapper = mapper;
        }

        public void AddCustomer(Customer customer)
        {
            var data = mapper.Map<Customer, CustomerData>(customer);
            database.Customers.Insert(data);
            database.Complete();
        }

        public void DeleteCustomer(Customer customer)
        {
            var data = mapper.Map<Customer, CustomerData>(customer);
            database.Customers.Delete(data);
            database.Complete();
        }

        public void DeleteCustomer(int id)
        {
            database.Customers.Delete(id);
            database.Complete();
        }

        public void UpdateCustomer(Customer customer)
        {
            var data = mapper.Map<Customer, CustomerData>(customer);
            database.Customers.Update(data);
            database.Complete();
        }

        public Customer GetCustomer(int id)
        {
            var data = database.Customers.Get(id);
            return mapper.Map<CustomerData, Customer>(data);
        }

        public IList<Customer> GetAll()
        {
            var data = database.Customers.List();
            return data.Select( d => mapper.Map<CustomerData, Customer>(d))
                .ToList();
        }
    }
}
