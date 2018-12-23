using Benefits.DAL.Context;
using Benefits.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benefits.DAL.Repositories.Implementations
{
    public class RestaurantTypeRepository : RepositoryBase<RestaurantType>, IRestaurantTypeRepository
    {
        public RestaurantTypeRepository(WebApiContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
