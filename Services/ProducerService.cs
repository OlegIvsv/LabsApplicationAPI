using AutoMapper;
using LabsApplication.DTOModels;
using LabsApplicationAPI.Models;
using LabsApplication.UnitOfWork.Interfaces;
using LabsApplicationAPI.Interfaces;
using LabsApplicationAPI.Mapping;

namespace LabsApplicationAPI.Services
{
    public class ProducerService : IProducerService
    {
        private IUnitOfWork unitOfWork;
        private IMapper mapper;

        public ProducerService(IUnitOfWork uof, IMapper mapper)
        {
            this.unitOfWork = uof;
            this.mapper = mapper;
        }

        public void AddProducer(Producer producer)
        {
            var data = mapper.Map<Producer, ProducerData>(producer);
            unitOfWork.Producers.Insert(data);
        }

        public void DeleteProducer(Producer producer)
        {
            var data = mapper.Map<Producer, ProducerData>(producer);
            unitOfWork.Producers.Delete(data);
        }

        public void DeleteProducer(int id)
        {
            unitOfWork.Producers.Delete(id);
        }

        public Producer GetProducer(int id)
        {
            var data = unitOfWork.Producers.Get(id);
            return mapper.Map<ProducerData, Producer>(data);
        }

        public void UpdateProducer(Producer producer)
        {
            var data = mapper.Map<Producer, ProducerData>(producer);
            unitOfWork.Producers.Update(data);
        }

        public IList<Producer> GetAll()
        {
            var data = unitOfWork.Producers.List();
            return data.Select(d => mapper.Map<ProducerData, Producer>(d))
                .ToList();
        }
    }
}
