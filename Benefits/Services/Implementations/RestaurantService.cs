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
using Benefits.DAL.Entities;

namespace Benefits.Services.Implementations
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IRestaurantTypeRepository _restaurantTypeRepository;
        private readonly IMapper _mapper;
        public RestaurantService(IMapper mapper, IRestaurantRepository restaurantRepository, IRestaurantTypeRepository restaurantTypeRepository)
        {
            _mapper = mapper;
            _restaurantRepository = restaurantRepository;
            _restaurantTypeRepository = restaurantTypeRepository;
        }

        public void Create(CreateRestaurantRequest model)
        {
            var entity = _mapper.Map<Restaurant>(model);
            var id=_restaurantRepository.Create(entity);
            _restaurantRepository.Save();
            model.TypeOfKitchens.ForEach(m => {
                _restaurantTypeRepository.Create(new RestaurantType
                {
                    RestaurantId = id,
                    TypeOfKitchenId = m
                });
            });
            _restaurantTypeRepository.Save();
        }

        public void Delete(int id)
        {
            var entity = _restaurantRepository.GetById(id);
            if (entity == null)
                return;
            _restaurantRepository.Delete(entity);
            _restaurantRepository.Save();
            var types = _restaurantTypeRepository.GetByCondition(m => m.RestaurantId == id);
            foreach (var item in types)
            {
                _restaurantTypeRepository.Delete(item);
            }
            _restaurantTypeRepository.Save();
        }

        public void Update(UpdateRestaurantRequest model)
        {
            var entity = _restaurantRepository.GetById(model.Id);
            if (entity == null)
                return;
            entity = _mapper.Map<Restaurant>(model);
            _restaurantRepository.Update(entity);
            _restaurantRepository.Save();
            var types=_restaurantTypeRepository.GetByCondition(m => m.RestaurantId == model.Id);
            foreach(var item in types)
            {
                _restaurantTypeRepository.Delete(item);
            }
            model.TypeOfKitchens.ForEach(m => {
                _restaurantTypeRepository.Create(new RestaurantType
                {
                    RestaurantId = model.Id,
                    TypeOfKitchenId = m
                });
            });
            _restaurantTypeRepository.Save();
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