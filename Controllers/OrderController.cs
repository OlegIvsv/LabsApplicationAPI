using AutoMapper;
using LabsApplication.DTOModels;
using LabsApplicationAPI.Interfaces;
using LabsApplicationAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LabsApplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IOrderService orderService;
        private IMapper mapper;

        public OrderController(IOrderService orderService, IMapper mapper)
        {
            this.orderService = orderService;
            this.mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<object> Get()
        {
            return orderService.GetAll();
        }

        [HttpGet("{id}")]
        public object Get(int id)
        {
            return orderService.GetOrder(id);
        }

        [HttpPost]
        public void Post([FromBody] OrderVM order)
        {
            var dtoModel = mapper.Map <OrderVM, OrderDTO> (order);
            orderService.AddOrder(dtoModel);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] OrderVM order)
        {
            var dtoModel = mapper.Map<OrderVM, OrderDTO>(order);
            orderService.UpdateOrder(dtoModel);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            orderService.DeleteOrder(id);
        }
    }
}
