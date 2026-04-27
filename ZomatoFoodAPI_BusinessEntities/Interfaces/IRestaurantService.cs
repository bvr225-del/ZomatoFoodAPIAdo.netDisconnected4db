using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZomatoFoodAPI_BusinessEntities.Dtos;
using ZomatoFoodAPI_BusinessEntities.Models;

namespace ZomatoFoodAPI_BusinessEntities.Interfaces
{
    public interface IRestaurantService
    {//in services we used Dto classes.
        Task<bool> AddRestaurant(RestaurantDto Objres);
        Task<bool> UpdateRestaurant(RestaurantDto Objres);
        Task<bool> DeleteRestaurant(int Id);
        Task<List<RestaurantDto>> GetallRestaurants();
        Task<RestaurantDto> GetRestaurantById(int Id);
    }
}
