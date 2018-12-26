using Benefits.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benefits.Services.Interfaces
{
    public interface IClientObjectService
    {
        void AddClientToRestaurant(AddClientToRestaurantRequest model);
        void AddClientToGym(AddClientToGymRequest model);
    }
}
