using AutoMapper;
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
        public readonly IRestaurantRepository _restaurantRepository;
        private readonly IMapper _mapper;
        public RestaurantService(IRestaurantRepository restaurantRepository, IMapper mapper)
        {
            _restaurantRepository = restaurantRepository;
            this._mapper = mapper;
        }

        public async Task<bool> AddRestaurant(RestaurantDto Objres)
        {
            Restaurant res = new Restaurant();
            _mapper.Map(Objres, res);
            var result = await _restaurantRepository.AddRestaurant(res);
            return true;

        }

        public async Task<bool> DeleteRestaurant(int Id)
        {
            await _restaurantRepository.DeleteRestaurant(Id);
            return true;
        }

        public async Task<List<RestaurantDto>> GetallRestaurants()
        {
            var res = await _restaurantRepository.GetallRestaurants();
            return _mapper.Map<List<RestaurantDto>>(res);
        }

        public async Task<RestaurantDto> GetRestaurantById(int Id)
        {
            var res = await _restaurantRepository.GetRestaurantById(Id);
            return _mapper.Map<RestaurantDto>(res);

        }

        public async Task<bool> UpdateRestaurant(RestaurantDto Objres)
        {
            Restaurant res = new Restaurant();
            _mapper.Map(Objres, res);
            var result = await _restaurantRepository.UpdateRestaurant(res);
            return true;

        }
    }
}