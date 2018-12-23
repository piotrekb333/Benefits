using AutoMapper;
using Benefits.DAL.Entities;
using Benefits.DAL.Repositories.Interfaces;
using Benefits.Models.Requests;
using Benefits.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Benefits.Services.Implementations
{
    public class ClientObjectService : IClientObjectService
    {
        private readonly IClientObjectRepository _clientObjectRepository;
        private readonly IMapper _mapper;
        public ClientObjectService(IMapper mapper, IClientObjectRepository clientObjectRepository)
        {
            _mapper = mapper;
            _clientObjectRepository = clientObjectRepository;
        }
        public void AddClientToRestaurant(AddClientToObjectRequest model)
        {
            var entity = _mapper.Map<ClientObject>(model);
            entity.GymId = null;
            _clientObjectRepository.Create(entity);
            _clientObjectRepository.Save();
        }

        public void AddClientToGym(AddClientToObjectRequest model)
        {
            var entity = _mapper.Map<ClientObject>(model);
            entity.RestaurantId = null;
            _clientObjectRepository.Create(entity);
            _clientObjectRepository.Save();
        }
    }
}