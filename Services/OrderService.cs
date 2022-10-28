using LabsApplication.DTOModels;
using LabsApplication.UnitOfWork.EF.Models;
using LabsApplication.UnitOfWork.Interfaces;
using LabsApplicationAPI.Interfaces;

namespace LabsApplicationAPI.Services
{
    public class OrderService : IOrderService
    {
        private IUnitOfWork unitOfWork;

        public OrderService(IUnitOfWork uof)
        {
            this.unitOfWork = uof;
        }


        public void AddOrder(OrderDTO order)
        {
            unitOfWork.Orders.Insert(order);
        }

        public void DeleteOrder(OrderDTO order)
        {
            unitOfWork.Orders.Delete(order);
        }

        public void DeleteOrder(int id)
        {
            unitOfWork.Orders.Delete(id);
        }

        public OrderDTO GetOrder(int id)
        {
           return unitOfWork.Orders.Get(id);
        }

        public IList<OrderDTO> GetAll()
        {
            return unitOfWork.Orders.List();
        }

        public void UpdateOrder(OrderDTO order)
        {
            unitOfWork.Orders.Update(order);
        }
    }
}
