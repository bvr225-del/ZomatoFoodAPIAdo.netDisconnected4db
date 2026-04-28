using AutoMapper;
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
        public readonly IOrdersRepository _ordersRepository;
        private readonly IMapper _mapper;
        //To implement dependency injection in the service class,
        //we need to inject the repository interface in the constructor of the service class
        //and assign it to the private readonly field of the repository interface type.
        //This way we can use the repository methods in the service class to perform the CRUD operations on the database.
        public OrdersService(IOrdersRepository ordersRepository,IMapper mapper)
        {
            _ordersRepository = ordersRepository;
            _mapper = mapper;
        }

        public async Task<bool> AddOrder(OrdersDto Objord)
        {
            Orders objorder = new Orders();
            _mapper.Map(Objord, objorder);
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
            var getorder = await _ordersRepository.GetallOrders();
            return _mapper.Map<List<OrdersDto>>(getorder);
        }

        public async Task<OrdersDto> GetOrderById(int Id)
        {
            var res = await _ordersRepository.GetOrderById(Id);
            return _mapper.Map<OrdersDto>(res);
        }

        public async Task<bool> UpdateOrder(OrdersDto Objord)
        {

            Orders order = new Orders();
            _mapper.Map(Objord, order);
            await _ordersRepository.UpdateOrder(order);
            return true;
        }
    }
}
