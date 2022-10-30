using LabsApplication.DTOModels;
using LabsApplicationAPI.Models;

namespace LabsApplicationAPI.Interfaces
{
    public interface IOrderService
    {
        Order GetOrder(int id);

        IList<Order> GetAll();

        void AddOrder(Order order);

        void DeleteOrder(Order order);

        void DeleteOrder(int id);

        void UpdateOrder(Order order);
    }
}
