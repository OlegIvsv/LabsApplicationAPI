using LabsApplication.DTOModels;
using LabsApplication.UnitOfWork.EF.Models;

namespace LabsApplicationAPI.Interfaces
{
    public interface IOrderService
    {
        OrderDTO GetOrder(int id);

        IList<OrderDTO> GetAll();

        void AddOrder(OrderDTO order);

        void DeleteOrder(OrderDTO order);

        void DeleteOrder(int id);

        void UpdateOrder(OrderDTO order);
    }
}
