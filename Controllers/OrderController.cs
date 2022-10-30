using AutoMapper;
using LabsApplication.DTOModels;
using LabsApplicationAPI.Interfaces;
using LabsApplicationAPI.Models;
using LabsApplicationAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ninject.Infrastructure.Language;

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
        public IEnumerable<OrderVM> Get()
        {
            var data = orderService.GetAll();
            return mapper.Map<IEnumerable<OrderVM>>(data);
        }

        [HttpGet("{id}")]
        public object Get(int id)
        {
            return orderService.GetOrder(id);
        }

        [HttpPost]
        public void Post([FromBody] OrderVM order)
        {
            var orders = mapper.Map <OrderVM, Order>(order);
            orderService.AddOrder(orders);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] OrderVM order)
        {
            var o = mapper.Map<OrderVM, Order>(order);
            orderService.UpdateOrder(o);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            orderService.DeleteOrder(id);
        }
    }
}
