using Benefits.DAL.Context;
using Benefits.DAL.Entities;
using Benefits.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benefits.DAL.Repositories.Implementations
{
    public class ClientGymRepository : RepositoryBase<ClientGym>, IClientGymRepository
    {
        public ClientGymRepository(WebApiContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
