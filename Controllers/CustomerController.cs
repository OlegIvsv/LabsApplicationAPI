using AutoMapper;
using AutoMapper.Configuration.Annotations;
using LabsApplication.DTOModels;
using LabsApplicationAPI.Interfaces;
using LabsApplicationAPI.Models;
using LabsApplicationAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Immutable;

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
        public IResult Get()
        {
            var customers = customerService.GetAll();
            var result = mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerVM>>(customers);
            return Results.Ok(result);
        }

        [HttpGet("{id:int:min(1)}")]
        public IResult Get(int id)
        {
            var data = customerService.GetCustomer(id);

            if(data is null)
                return Results.NotFound();
            
            var result = mapper.Map<CustomerVM>(data);
            return Results.Ok(result);
        }

        [HttpPost]
        public IResult Post([FromBody] NewCustomerVM customer)
        {          
            if (ModelState.IsValid is false)
            {
                var errorDictionary = ModelState.AsValidationDictionary();
                return Results.ValidationProblem(errorDictionary);
            }
            
            var c = mapper.Map<NewCustomerVM, Customer>(customer);
            customerService.AddCustomer(c);
            return Results.Ok();
        }

        [HttpPut("{id:int:min(1)}")]
        public IResult Put(CustomerVM customer)
        {
            if (ModelState.IsValid is false)
            {
                var errorDictionary = ModelState.AsValidationDictionary();
                return Results.ValidationProblem(errorDictionary);
            }

            var c = customerService.GetCustomer(customer.Id);
            mapper.Map(customer, c);
            customerService.UpdateCustomer(c);
            return Results.Ok();
        }

        [HttpDelete("{id:int:min(1)}")]
        public IResult Delete(int id)
        {
            customerService.DeleteCustomer(id);
            return Results.Ok();
        }
    }
}
