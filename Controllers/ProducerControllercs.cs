using AutoMapper;
using LabsApplication.DTOModels;
using LabsApplicationAPI.Interfaces;
using LabsApplicationAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LabsApplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProducerControllercs : ControllerBase
    {
        private IProducerService producerService;
        private IMapper mapper;

        public ProducerControllercs(IProducerService producerService, IMapper mapper)
        {
            this.producerService = producerService;
            this.mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<object> Get()
        {
            return producerService.GetAll();
        }

        [HttpGet("{id}")]
        public object Get(int id)
        {
            return producerService.GetProducer(id);
        }

        [HttpPost]
        public void Post([FromBody] ProducerVM producer)
        {
            var dtoModel = mapper.Map<ProducerVM, ProducerDTO>(producer);
            producerService.AddProducer(dtoModel);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ProducerVM producer)
        {
            var dtoModel = mapper.Map<ProducerVM, ProducerDTO>(producer);
            producerService.UpdateProducer(dtoModel);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            producerService.DeleteProducer(id);
        }
    }
}
