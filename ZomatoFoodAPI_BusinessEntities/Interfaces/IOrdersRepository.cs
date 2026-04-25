using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZomatoFoodAPI_BusinessEntities.Models;

namespace ZomatoFoodAPI_BusinessEntities.Interfaces
{
    public interface IOrdersRepository
    {
        Task<bool> AddOrder(Orders Objord);
        Task<bool> UpdateOrder(Orders Objord);
        Task<bool> DeleteOrder(int OrderId);
        Task<List<Orders>> GetallOrders();
        Task<Orders> GetOrderById(int Id);  
    }
}
