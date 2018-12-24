using Benefits.Models.DtoModels;
using Benefits.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benefits.Services.Interfaces
{
    public interface IRestaurantService
    {
        void Create(CreateRestaurantRequest model);
        void Update(UpdateRestaurantRequest model);
        void Delete(int id);
        RestaurantDto GetById(int id);
        List<RestaurantDto> GetAll();

    }
}
