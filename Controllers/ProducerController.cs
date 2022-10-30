using AutoMapper;
using LabsApplication.DTOModels;
using LabsApplicationAPI.Interfaces;
using LabsApplicationAPI.Models;
using LabsApplicationAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LabsApplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProducerController : ControllerBase
    {
        private IProducerService producerService;
        private IMapper mapper;

        public ProducerController(IProducerService producerService, IMapper mapper)
        {
            this.producerService = producerService;
            this.mapper = mapper;
        }


        [HttpGet]
        public IResult Get()
        {
            var producers = producerService.GetAll();
            var result = mapper.Map<IEnumerable<ProducerVM>>(producers);
            return Results.Json(result);
        }

        [HttpGet("{id:int:min(1)}")]
        public IResult Get(int id)
        {
            var p = producerService.GetProducer(id);
            if(p is null)
                return Results.BadRequest("Data was not found!");

            var result = mapper.Map<ProducerVM>(p);
            return Results.Json(result);
        }

        [HttpPost]
        public IResult Post([FromBody] ProducerVM producer)
        {
            if (ModelState.IsValid is false)
            {
                var errorDictionary = ModelState.AsValidationDictionary();
                return Results.ValidationProblem(errorDictionary);
            }

            var p = mapper.Map<ProducerVM, Producer>(producer);
            producerService.AddProducer(p);
            return Results.Ok();
        }

        [HttpPut("{id:int:min(1)}")]
        public IResult Put(int id, [FromBody] ProducerVM producer)
        {
            if (ModelState.IsValid is false)
            {
                var errorDictionary = ModelState.AsValidationDictionary();
                return Results.ValidationProblem(errorDictionary);
            }

            var p = mapper.Map<ProducerVM, Producer>(producer);
            producerService.UpdateProducer(p);
            return Results.Ok();
        }

        [HttpDelete("{id:int:min(1)}")]
        public IResult Delete(int id)
        {
            producerService.DeleteProducer(id);
            return Results.Ok();
        }
    }
}
