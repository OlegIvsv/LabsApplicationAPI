using LabsApplication.DTOModels;
using LabsApplication.UnitOfWork.EF.Models;
using LabsApplication.UnitOfWork.Interfaces;
using LabsApplicationAPI.Interfaces;

namespace LabsApplicationAPI.Services
{
    public class ProducerService : IProducerService
    {
        private IUnitOfWork unitOfWork;

        public ProducerService(IUnitOfWork uof)
        {
            this.unitOfWork = uof;
        }

        public void AddProducer(ProducerDTO producer)
        {
            unitOfWork.Producers.Insert(producer);
        }

        public void DeleteProducer(ProducerDTO producer)
        {
            unitOfWork.Producers.Delete(producer);
        }

        public void DeleteProducer(int id)
        {
            unitOfWork.Producers.Delete(id);
        }

        public ProducerDTO GetProducer(int id)
        {
            return unitOfWork.Producers.Get(id);
        }

        public void UpdateProducer(ProducerDTO producer)
        {
            unitOfWork.Producers.Update(producer);
        }

        public IList<ProducerDTO> GetAll()
        {
            return unitOfWork.Producers.List();
        }
    }
}
