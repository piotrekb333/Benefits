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
        void Update(int id);
        void Delete(int id);
    }
}
