using AutoMapper;
using Benefits.DAL.Entities;
using Benefits.Models.DtoModels;
using Benefits.Models.Entities;
using Benefits.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Benefits.Configuration
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            CreateMap<Restaurant, RestaurantDto>();
            CreateMap<RestaurantDto, Restaurant>();
            CreateMap<Gym, GymDto>();
            CreateMap<GymDto, Gym>();

            CreateMap<ClientGym, AddClientToGymRequest>();
            CreateMap<AddClientToGymRequest, ClientGym>();
            CreateMap<ClientRestaurant, AddClientToRestaurantRequest>();
            CreateMap<AddClientToRestaurantRequest, ClientRestaurant>();
            CreateMap<Gym, UpdateGymRequest>();
            CreateMap<UpdateGymRequest, Gym>();
            CreateMap<Restaurant, UpdateRestaurantRequest>();
            CreateMap<UpdateRestaurantRequest, Restaurant>();
            CreateMap<Gym, CreateGymRequest>();
            CreateMap<CreateGymRequest, Gym>();
            CreateMap<Restaurant, CreateRestaurantRequest>();
            CreateMap<CreateRestaurantRequest, Restaurant>();
        }
    }
}