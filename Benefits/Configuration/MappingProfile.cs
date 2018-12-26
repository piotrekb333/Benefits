using AutoMapper;
using Benefits.DAL.Entities;
using Benefits.Models.DtoModels;
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
            CreateMap<User, AddUserRequest>();
            CreateMap<AddUserRequest, User>();
            CreateMap<Restaurant, RestaurantDto>()
                .ForMember(c => c.CityName, o => o.MapFrom(s => s.City.Name))
                .ForMember(c => c.TypeOfKitchenDto, o => o.MapFrom(s => s.RestaurantTypeOfKitchens.Select(d=>d.TypeOfKitchen)));
            CreateMap<RestaurantDto, Restaurant>();
            CreateMap<Gym, GymDto>()
                .ForMember(c => c.CityName, o => o.MapFrom(s => s.City.Name));
            CreateMap<TypeOfKitchen, TypeOfKitchenDto>();
            CreateMap<TypeOfKitchenDto, TypeOfKitchen>();

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