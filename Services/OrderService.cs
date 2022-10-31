using AutoMapper;
using LabsApplication.DTOModels;
using LabsApplication.UnitOfWork.Interfaces;
using LabsApplicationAPI.Interfaces;
using LabsApplicationAPI.Models;

namespace LabsApplicationAPI.Services
{
    public class OrderService : IOrderService
    {
        private IAppDatabase database;
        private IMapper mapper;

        public OrderService(IAppDatabase database, IMapper mapper)
        {
            this.database = database;
            this.mapper = mapper;
        }


        public void AddOrder(Order order)
        {
            var data = mapper.Map<Order, OrderData>(order);
            //set time here
            data.CreationTime = DateTime.Now;

            database.Orders.Insert(data);
            database.Complete();
        }

        public void DeleteOrder(Order order)
        {
            var data = mapper.Map<Order, OrderData>(order);
            database.Orders.Delete(data);
            database.Complete();
        }

        public void DeleteOrder(int id)
        {
            database.Orders.Delete(id);
            database.Complete();
        }

        public Order GetOrder(int id)
        {
           var data = database.Orders.Get(id);
           return mapper.Map<OrderData, Order>(data);
        }

        public IList<Order> GetAll()
        {
            var data = database.Orders.List();
            return data.Select(d => mapper.Map<OrderData, Order>(d))
                .ToList();
        }

        public void UpdateOrder(Order order)
        {
            var orderData = database.Orders.Get(order.Id);
            mapper.Map(order, orderData);

            database.Orders.Update(orderData);
            database.Complete();
        }
    }
}
