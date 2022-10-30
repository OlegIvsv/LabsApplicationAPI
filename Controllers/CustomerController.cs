using AutoMapper;
using LabsApplication.DTOModels;
using LabsApplicationAPI.Interfaces;
using LabsApplicationAPI.Models;
using LabsApplicationAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LabsApplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ICustomerService customerService;
        private IMapper mapper;

        public CustomerController(ICustomerService customerService, IMapper mapper)
        {
            this.customerService = customerService;
            this.mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<CustomerVM> Get()
        {
            var customers = customerService.GetAll();
            return mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerVM>>(customers);
        }

        [HttpGet("{id}")]
        public CustomerVM Get(int id)
        {
            var data = customerService.GetCustomer(id);
            return mapper.Map<CustomerVM>(data);    

        }

        [HttpPost]
        public void Post([FromBody] CustomerVM customer)
        {
            var c = mapper.Map<CustomerVM, Customer>(customer);
            customerService.AddCustomer(c);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] CustomerVM customer)
        {
            var c = mapper.Map<CustomerVM, Customer>(customer);
            customerService.UpdateCustomer(c);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            customerService.DeleteCustomer(id);
        }
    }
}
