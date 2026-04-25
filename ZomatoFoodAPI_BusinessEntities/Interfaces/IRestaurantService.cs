using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZomatoFoodAPI_BusinessEntities.Models;

namespace ZomatoFoodAPI_BusinessEntities.Interfaces
{
    public interface IRestaurantService
    {//in services we used Dto classes.
        Task<bool> AddRestaurant(Restaurant Objres);
        Task<bool> UpdateRestaurant(Restaurant Objres);
        Task<bool> DeleteRestaurant(int Id);
        Task<List<Restaurant>> GetallRestaurants();
        Task<Restaurant> GetRestaurantById(int Id);
    }
}
