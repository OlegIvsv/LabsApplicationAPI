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
        private IAppDatabase database;
        private IMapper mapper;

        public ProducerService(IAppDatabase database, IMapper mapper)
        {
            this.database = database;
            this.mapper = mapper;
        }

        public void AddProducer(Producer producer)
        {
            var data = mapper.Map<Producer, ProducerData>(producer);
            database.Producers.Insert(data);
            database.Complete();
        }

        public void DeleteProducer(Producer producer)
        {
            var data = mapper.Map<Producer, ProducerData>(producer);
            database.Producers.Delete(data);
            database.Complete();
        }

        public void DeleteProducer(int id)
        {
            database.Producers.Delete(id);
            database.Complete();
        }

        public Producer GetProducer(int id)
        {
            var data = database.Producers.Get(id);
            return mapper.Map<ProducerData, Producer>(data);
        }

        public void UpdateProducer(Producer producer)
        {
            var data = mapper.Map<Producer, ProducerData>(producer);
            database.Producers.Update(data);
            database.Complete();
        }

        public IList<Producer> GetAll()
        {
            var data = database.Producers.List();
            return data.Select(d => mapper.Map<ProducerData, Producer>(d))
                .ToList();
        }
    }
}
