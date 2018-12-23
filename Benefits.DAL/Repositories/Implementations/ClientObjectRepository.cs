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
    public class ClientObjectRepository : RepositoryBase<ClientObject>, IClientObjectRepository
    {
        public ClientObjectRepository(WebApiContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
