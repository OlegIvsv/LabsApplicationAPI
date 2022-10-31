using AutoMapper;
using LabsApplication.DTOModels;
using LabsApplicationAPI.Interfaces;
using LabsApplicationAPI.Models;
using LabsApplicationAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
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
        public IResult Get()
        {
            var data = orderService.GetAll();
            var result = mapper.Map<IEnumerable<OrderVM>>(data);
            return Results.Json(result);
        }

        [HttpGet("{id:int:min(1)}")]
        public object Get(int id)
        {
            var data = orderService.GetOrder(id);

            if (data is null)
                return Results.NotFound();

            mapper.Map<OrderVM>(data);
            return Results.Json(data);
        }

        [HttpPost]
        public IResult Post([FromBody]NewOrderVM order)
        {
            if (ModelState.IsValid is false)
            {
                var errorDictionary = ModelState.AsValidationDictionary();
                return Results.ValidationProblem(errorDictionary);
            }

            var newOrder = mapper.Map<NewOrderVM, Order>(order);
            orderService.AddOrder(newOrder);
            return Results.Ok();
        }

        [HttpPut("{id:int:min(1)}")]
        public IResult Put([FromBody] OrderVM order)
        {
            if (ModelState.IsValid is false)
            {
                var errorDictionary = ModelState.AsValidationDictionary();
                return Results.ValidationProblem(errorDictionary);
            }

            var o = orderService.GetOrder(order.Id);
            mapper.Map(order, o);

            orderService.UpdateOrder(o);
            return Results.Ok();
        }

        [HttpDelete("{id:int:min(1)}")]
        public IResult Delete(int id)
        {
            orderService.DeleteOrder(id);
            return Results.Ok();
        }
    }
}
