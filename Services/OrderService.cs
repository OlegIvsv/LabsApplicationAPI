using AutoMapper;
using LabsApplication.DTOModels;
using LabsApplication.UnitOfWork.Interfaces;
using LabsApplicationAPI.Interfaces;
using LabsApplicationAPI.Models;

namespace LabsApplicationAPI.Services
{
    public class OrderService : IOrderService
    {
        private IUnitOfWork unitOfWork;
        private IMapper mapper;

        public OrderService(IUnitOfWork uof, IMapper mapper)
        {
            this.unitOfWork = uof;
            this.mapper = mapper;
        }


        public void AddOrder(Order order)
        {
            var data = mapper.Map<Order, OrderData>(order);
            unitOfWork.Orders.Insert(data);
        }

        public void DeleteOrder(Order order)
        {
            var data = mapper.Map<Order, OrderData>(order);
            unitOfWork.Orders.Delete(data);
        }

        public void DeleteOrder(int id)
        {
            unitOfWork.Orders.Delete(id);
        }

        public Order GetOrder(int id)
        {
           var data = unitOfWork.Orders.Get(id);
           return mapper.Map<OrderData, Order>(data);
        }

        public IList<Order> GetAll()
        {
            var data = unitOfWork.Orders.List();
            return data.Select(d => mapper.Map<OrderData, Order>(d))
                .ToList();
        }

        public void UpdateOrder(Order order)
        {
            var data = mapper.Map<Order, OrderData>(order);
            unitOfWork.Orders.Update(data);
        }
    }
}
