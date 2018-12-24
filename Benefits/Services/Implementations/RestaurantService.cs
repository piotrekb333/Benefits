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
using Benefits.DAL.Context;

namespace Benefits.Services.Implementations
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IRestaurantTypeRepository _restaurantTypeRepository;
        private readonly IRestaurantUnitOfWork _restaurantUnitOfWork;
        private readonly IMapper _mapper;
        public RestaurantService(IMapper mapper, IRestaurantRepository restaurantRepository, IRestaurantTypeRepository restaurantTypeRepository,
            IRestaurantUnitOfWork restaurantUnitOfWork)
        {
            _mapper = mapper;
            _restaurantRepository = restaurantRepository;
            _restaurantTypeRepository = restaurantTypeRepository;
            _restaurantUnitOfWork = restaurantUnitOfWork;
        }

        public void Create(CreateRestaurantRequest model)
        {
            _restaurantUnitOfWork.BeginTransaction();
            var entity = _mapper.Map<Restaurant>(model);
            var id= _restaurantUnitOfWork.GetRestaurantRepository().Create(entity);
            _restaurantUnitOfWork.GetRestaurantRepository().Save();
            model.TypeOfKitchens.ForEach(m => {
                _restaurantUnitOfWork.GetRestaurantTypeRepository().Create(new RestaurantType
                {
                    RestaurantId = id,
                    TypeOfKitchenId = m
                });
            });
            _restaurantUnitOfWork.GetRestaurantTypeRepository().Save();
            _restaurantUnitOfWork.CommitTransaction();
        }

        public void Delete(int id)
        {
            _restaurantUnitOfWork.BeginTransaction();
            var entity = _restaurantUnitOfWork.GetRestaurantRepository().GetById(id);
            if (entity == null)
                return;
            var types = _restaurantUnitOfWork.GetRestaurantTypeRepository().GetByCondition(m => m.RestaurantId == id);
            foreach (var item in types)
            {
                _restaurantTypeRepository.Delete(item);
            }
            _restaurantUnitOfWork.GetRestaurantTypeRepository().Save();
            _restaurantUnitOfWork.GetRestaurantRepository().Delete(entity);
            _restaurantUnitOfWork.GetRestaurantRepository().Save();
            _restaurantUnitOfWork.CommitTransaction();
        }

        public void Update(UpdateRestaurantRequest model)
        {
            _restaurantUnitOfWork.BeginTransaction();
            var entity = _restaurantUnitOfWork.GetRestaurantRepository().GetById(model.Id);
            if (entity == null)
                return;
            entity = _mapper.Map<Restaurant>(model);
            _restaurantUnitOfWork.GetRestaurantRepository().Update(entity);
            _restaurantUnitOfWork.GetRestaurantRepository().Save();
            var types= _restaurantUnitOfWork.GetRestaurantTypeRepository().GetByCondition(m => m.RestaurantId == model.Id);
            foreach(var item in types)
            {
                _restaurantUnitOfWork.GetRestaurantTypeRepository().Delete(item);
            }
            model.TypeOfKitchens.ForEach(m => {
                _restaurantUnitOfWork.GetRestaurantTypeRepository().Create(new RestaurantType
                {
                    RestaurantId = model.Id,
                    TypeOfKitchenId = m
                });
            });
            _restaurantUnitOfWork.GetRestaurantTypeRepository().Save();
            _restaurantUnitOfWork.CommitTransaction();
        }
        public RestaurantDto GetById(int id)
        {
            var entity = _restaurantRepository.GetById(id);
            if (entity == null)
                return null;
            var result = _mapper.Map<RestaurantDto>(entity);
            return result;
        }

        public List<RestaurantDto> GetAll()
        {
            var entity = _restaurantRepository.GetAll();
            var result = _mapper.Map<List<RestaurantDto>>(entity);
            return result;
        }
    }
}