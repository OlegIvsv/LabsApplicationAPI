using LabsApplication.DTOModels;
using LabsApplication.UnitOfWork.EF.Models;

namespace LabsApplicationAPI.Interfaces
{
    public interface IProducerService
    {
        ProducerDTO GetProducer(int id);

        void AddProducer(ProducerDTO producer);

        void DeleteProducer(ProducerDTO producer);
        
        void DeleteProducer(int id);

        void UpdateProducer(ProducerDTO producer);

        IList<ProducerDTO> GetAll();
    }
}
