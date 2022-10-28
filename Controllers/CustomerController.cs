using AutoMapper;
using LabsApplication.DTOModels;
using LabsApplication.UnitOfWork.EF.Models;
using LabsApplicationAPI.Interfaces;
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
        public IEnumerable<object> Get()
        {
            return customerService.GetAll();
        }

        [HttpGet("{id}")]
        public object Get(int id)
        {
            return customerService.GetCustomer(id);
        }

        [HttpPost]
        public void Post([FromBody] CustomerVM customer)
        {
            var dtoModel = mapper.Map<CustomerVM, CustomerDTO>(customer);
            customerService.AddCustomer(dtoModel);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] CustomerVM customer)
        {
            var dtoModel = mapper.Map<CustomerVM, CustomerDTO>(customer);
            customerService.UpdateCustomer(dtoModel);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            customerService.DeleteCustomer(id);
        }
    }
}
