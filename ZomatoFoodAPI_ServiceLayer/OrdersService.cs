using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZomatoFoodAPI_BusinessEntities.Dtos;
using ZomatoFoodAPI_BusinessEntities.Interfaces;
using ZomatoFoodAPI_BusinessEntities.Models;
using ZomatoFoodAPI_RepositoryLayer;

namespace ZomatoFoodAPI_ServiceLayer
{
    public class OrdersService : IOrdersService
    {
        private readonly IOrdersRepository _ordersRepository;
        //To implement dependency injection in the service class,
        //we need to inject the repository interface in the constructor of the service class
        //and assign it to the private readonly field of the repository interface type.
        //This way we can use the repository methods in the service class to perform the CRUD operations on the database.
        public OrdersService(IOrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }

        public async Task<bool> AddOrder(OrdersDto Objord)
        {
            Orders objorder = new Orders();
            objorder.OrderLocation = Objord.OrderLocation;
            objorder.OrderName = Objord.OrderName;
            var res = await _ordersRepository.AddOrder(objorder);
            return res;
        }

        public async Task<bool> DeleteOrder(int OrderId)
        {
            await _ordersRepository.DeleteOrder(OrderId);
            return true;
        }

        public async Task<List<OrdersDto>> GetallOrders()
        {
            List<OrdersDto> ordlist = new List<OrdersDto>();
            var getorder = await _ordersRepository.GetallOrders();
            foreach (var order in getorder)
            {
                OrdersDto ordobj = new OrdersDto();
                ordobj.OrderId = order.OrderId;
                ordobj.OrderName = order.OrderName;
                ordobj.OrderLocation = order.OrderLocation;
                ordlist.Add(ordobj);


            }
            return ordlist;
        }

        public async Task<OrdersDto> GetOrderById(int Id)
        {
            var res = await _ordersRepository.GetOrderById(Id);
            OrdersDto objorder = new OrdersDto();
            objorder.OrderId = res.OrderId;
            objorder.OrderName = res.OrderName;
            objorder.OrderLocation = res.OrderLocation;
            return objorder;
        }

        public async Task<bool> UpdateOrder(OrdersDto Objord)
        {

            Orders order = new Orders();
            order.OrderId = Objord.OrderId;
            order.OrderName = Objord.OrderName;
            order.OrderLocation = Objord.OrderLocation;
            await _ordersRepository.UpdateOrder(order);
            return true;
        }
    }
}
