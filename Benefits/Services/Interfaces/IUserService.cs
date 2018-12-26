using Benefits.Models.DtoModels;
using Benefits.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Benefits.Services.Interfaces
{
    public interface IUserService
    {
        UserDto Authenticate(string username, string password);
        void Create(AddUserRequest model);
    }
}
