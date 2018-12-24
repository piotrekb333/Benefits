using AutoMapper;
using Benefits.DAL.Entities;
using Benefits.DAL.Repositories.Interfaces;
using Benefits.Models.Entities;
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
        private readonly IClientRestaurantRepository _clientRestaurantRepository;
        private readonly IClientGymRepository _clientGymRepository;
        private readonly IMapper _mapper;
        public ClientObjectService(IMapper mapper, IClientRestaurantRepository clientRestaurantRepository, IClientGymRepository clientGymRepository)
        {
            _mapper = mapper;
            _clientRestaurantRepository = clientRestaurantRepository;
            _clientGymRepository = clientGymRepository;
        }
        public void AddClientToRestaurant(AddClientToRestaurantRequest model)
        {
            var entity = _mapper.Map<ClientRestaurant>(model);
            _clientRestaurantRepository.Create(entity);
            _clientRestaurantRepository.Save();
        }

        public void AddClientToGym(AddClientToRestaurantRequest model)
        {
            var entity = _mapper.Map<ClientGym>(model);
            _clientGymRepository.Create(entity);
            _clientGymRepository.Save();
        }
    }
}