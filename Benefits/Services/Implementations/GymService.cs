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
    public class GymService : IGymService
    {
        private readonly IGymRepository _gymRepository;
        private readonly IMapper _mapper;
        public GymService(IMapper mapper, IGymRepository gymRepository)
        {
            _mapper = mapper;
            _gymRepository = gymRepository;
        }

        public void Create(CreateGymRequest model)
        {
            var entity = _mapper.Map<Gym>(model);
            _gymRepository.Create(entity);
            _gymRepository.Save();
        }

        public void Delete(int id)
        {
            var entity = _gymRepository.GetById(id);
            if (entity == null)
                return;
            _gymRepository.Delete(entity);
            _gymRepository.Save();
        }

        public void Update(UpdateGymRequest model)
        {
            var entity = _gymRepository.GetById(model.Id);
            if (entity == null)
                return;
            entity = _mapper.Map<Gym>(model);
            _gymRepository.Update(entity);
            _gymRepository.Save();
        }
        public GymDto GetById(int id)
        {
            var entity=_gymRepository.GetById(id);
            if (entity == null)
                return null;
            var result = _mapper.Map<GymDto>(entity);
            return result;
        }
        public List<GymDto> GetAll()
        {
            var entity = _gymRepository.GetAll();
            var result = _mapper.Map<List<GymDto>>(entity);
            return result;
        }
    }
}