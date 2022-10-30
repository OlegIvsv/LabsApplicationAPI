using LabsApplication.DTOModels;
using LabsApplicationAPI.Models;

namespace LabsApplicationAPI.Interfaces
{
    public interface IProducerService
    {
        Producer GetProducer(int id);

        void AddProducer(Producer producer);

        void DeleteProducer(Producer producer);
        
        void DeleteProducer(int id);

        void UpdateProducer(Producer producer);

        IList<Producer> GetAll();
    }
}
