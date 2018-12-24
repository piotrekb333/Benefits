using AutoMapper;
using Benefits.DAL.Repositories.Interfaces;
using Benefits.Models.DtoModels;
using Benefits.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Benefits.Services.Implementations
{
    public class ReportService : IReportService
    {
        private readonly IClientGymRepository _clientGymRepository;
        private readonly IClientRestaurantRepository _clientRestaurantRepository;
        private readonly IMapper _mapper;

        public ReportService(IMapper mapper, IClientGymRepository clientGymRepository, IClientRestaurantRepository clientRestaurantRepository)
        {
            _mapper = mapper;
            _clientGymRepository = clientGymRepository;
            _clientRestaurantRepository = clientRestaurantRepository;
        }
        public List<ObjectsReportDto> GetObjectsReport(DateTime? dateFrom,DateTime? dateTo)
        {
            var resultGyms=_clientGymRepository.GetByCondition(m => m.Date >= (dateFrom ?? DateTime.MinValue) && m.Date <= (dateTo ?? DateTime.MaxValue));
            var resultRestaurants = _clientRestaurantRepository.GetByCondition(m => m.Date >= (dateFrom ?? DateTime.MinValue) && m.Date <= (dateTo ?? DateTime.MaxValue));
            var groupGyms = resultGyms.GroupBy(m => new { m.Gym.City.Name, m.Gym.CityId }).Select(m => new ObjectsReportDto {Type="Gym",City=m.Key.Name,NumberOfClients=m.Count() });
            var groupRestaurants = resultRestaurants.GroupBy(m => new { m.Restaurant.City.Name, m.Restaurant.CityId }).Select(m => new ObjectsReportDto { Type = "Restaurant", City = m.Key.Name, NumberOfClients = m.Count() });
            var result = groupGyms.Concat(groupRestaurants);
            result = result.OrderByDescending(m => m.NumberOfClients);
            return result.ToList();
        }
        public List<ClientsReportDto> GetClientsReport(DateTime? dateFrom, DateTime? dateTo)
        {
            var resultGyms = _clientGymRepository.GetByCondition(m => m.Date >= (dateFrom ?? DateTime.MinValue) && m.Date <= (dateTo ?? DateTime.MaxValue));
            var resultRestaurants = _clientRestaurantRepository.GetByCondition(m => m.Date >= (dateFrom ?? DateTime.MinValue) && m.Date <= (dateTo ?? DateTime.MaxValue));
            var groupGyms = resultGyms.GroupBy(m => new { m.ClientId, m.Client.Name,Month=m.Date.Month,Year=m.Date.Year }).Select(m => new ClientsReportDto { Name=m.Key.Name,Month=m.Key.Month,Year=m.Key.Year,NumberOfObjects=m.Count() });
            var groupRestaurants = resultRestaurants.GroupBy(m => new { m.ClientId, m.Client.Name, Month = m.Date.Month, Year = m.Date.Year }).Select(m => new ClientsReportDto { Name = m.Key.Name, Month = m.Key.Month, Year = m.Key.Year, NumberOfObjects = m.Count() });
            var result = groupGyms.Concat(groupRestaurants);
            return result.ToList();
        }
    }
}