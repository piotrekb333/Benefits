using Benefits.Models.DtoModels;
using Benefits.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benefits.Services.Interfaces
{
    public interface IGymService
    {
        void Create(CreateGymRequest model);
        void Update(UpdateGymRequest model);
        void Delete(int id);
        GymDto GetById(int id);
        List<GymDto> GetAll();
    }
}
