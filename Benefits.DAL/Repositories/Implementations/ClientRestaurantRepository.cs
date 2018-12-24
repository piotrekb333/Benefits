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
    public class ClientRestaurantRepository : RepositoryBase<ClientRestaurant>, IClientRestaurantRepository
    {
        public ClientRestaurantRepository(WebApiContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
