using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZomatoFoodAPI_BusinessEntities.Dtos;
using ZomatoFoodAPI_BusinessEntities.Interfaces;
using ZomatoFoodAPI_BusinessEntities.Models;

namespace ZomatoFoodAPI_ServiceLayer
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository _restaurantRepository;
        public RestaurantService(IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }
        public async Task<bool> AddRestaurant(Restaurant Objres)
        {
            Restaurant objres = new Restaurant();
            objres.RestaurantName = Objres.RestaurantName;
            objres.RestaurantLocation = Objres.RestaurantLocation;
            var res = await _restaurantRepository.AddRestaurant(objres);
            return res;

        }


        public async Task<bool> DeleteRestaurant(int Id)
        {
            await _restaurantRepository.DeleteRestaurant(Id);
            return true;
        }

        public async Task<List<Restaurant>> GetallRestaurants()
        {
            List<RestaurantDto> reslist = new List<RestaurantDto>();
            var getrestaurants = await _restaurantRepository.GetallRestaurants();
            foreach (var restaurant in getrestaurants)
            {
                RestaurantDto resobj = new RestaurantDto();
                resobj.Id = restaurant.Id;
                resobj.RestaurantName = restaurant.RestaurantName;
                resobj.RestaurantLocation = restaurant.RestaurantLocation;
                resobj.CreationDate = restaurant.CreationDate;
                reslist.Add(resobj);


            }
            return getrestaurants;

        }

        public async Task<Restaurant> GetRestaurantById(int Id)
        {
            var res = await _restaurantRepository.GetRestaurantById(Id);
            RestaurantDto objres = new RestaurantDto();
            objres.Id = res.Id;
            objres.RestaurantName = res.RestaurantName;
            objres.RestaurantLocation = res.RestaurantLocation;
            objres.CreationDate = res.CreationDate;
            return res;

        }

        public async Task<bool> UpdateRestaurant(Restaurant Objres)
        {
            Restaurant res = new Restaurant();
            res.Id = Objres.Id;
            res.RestaurantLocation = Objres.RestaurantLocation;
            res.RestaurantName = Objres.RestaurantName;
            await _restaurantRepository.UpdateRestaurant(res);
            return true;

        }
    }
}
