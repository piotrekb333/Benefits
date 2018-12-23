using AutoMapper;
using Benefits.DAL.Repositories;
using Benefits.DAL.Repositories.Interfaces;
using Benefits.Models.DtoModels;
using Benefits.Models.Requests;
using Benefits.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Benefits.Services.Implementations
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IMapper _mapper;
        public RestaurantService(IMapper mapper, IRestaurantRepository restaurantRepository)
        {
            _mapper = mapper;
            _restaurantRepository = restaurantRepository;
        }

        public void Create(CreateRestaurantRequest model)
        {
            var entity = _mapper.Map<Restaurant>(model);
            _restaurantRepository.Create(entity);
            _restaurantRepository.Save();
        }

        public void Delete(int id)
        {
            var entity = _restaurantRepository.GetById(id);
            if (entity == null)
                return;
            _restaurantRepository.Delete(entity);
            _restaurantRepository.Save();
        }

        public void Update(CreateRestaurantRequest model)
        {
            var entity = _restaurantRepository.GetById(model.Id);
            if (entity == null)
                return;
            entity = _mapper.Map<Restaurant>(model);
            _restaurantRepository.Update(entity);
            _restaurantRepository.Save();
        }
        public RestaurantDto GetById(int id)
        {
            var entity = _restaurantRepository.GetById(id);
            if (entity == null)
                return null;
            var result = _mapper.Map<RestaurantDto>(entity);
            return result;
        }
    }
}