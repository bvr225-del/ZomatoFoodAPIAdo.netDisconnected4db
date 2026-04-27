using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZomatoFoodAPI_BusinessEntities.Dtos;

namespace ZomatoFoodAPI_BusinessEntities.Interfaces
{
    public interface IOrdersService
    {
        //in services we used Dto classes.
        Task<bool> AddOrder(OrdersDto Objord);
        Task<bool> UpdateOrder(OrdersDto Objord);
        Task<bool> DeleteOrder(int OrderId);
        Task<List<OrdersDto>> GetallOrders();
        Task<OrdersDto> GetOrderById(int Id);
    }
}
