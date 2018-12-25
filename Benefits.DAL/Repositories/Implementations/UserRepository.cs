using Benefits.DAL.Context;
using Benefits.DAL.Repositories.Interfaces;
using Benefits.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Benefits.DAL.Repositories.Implementations
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(WebApiContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
