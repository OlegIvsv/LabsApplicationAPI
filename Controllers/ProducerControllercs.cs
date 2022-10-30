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
        public IEnumerable<ProducerVM> Get()
        {
            var producers = producerService.GetAll();
            return mapper.Map<IEnumerable<ProducerVM>>(producers);
        }

        [HttpGet("{id}")]
        public ProducerVM Get(int id)
        {
            var p = producerService.GetProducer(id);
            return mapper.Map<ProducerVM>(p);
        }

        [HttpPost]
        public void Post([FromBody] ProducerVM producer)
        {
            var p = mapper.Map<ProducerVM, Producer>(producer);
            producerService.AddProducer(p);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ProducerVM producer)
        {
            var p = mapper.Map<ProducerVM, Producer>(producer);
            producerService.UpdateProducer(p);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            producerService.DeleteProducer(id);
        }
    }
}
