using Benefits.DAL.Context;
using Benefits.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Benefits.DAL.Entities;

namespace Benefits.DAL.Repositories.Implementations
{
    public class RestaurantTypeOfKitchenRepository : RepositoryBase<RestaurantTypeOfKitchen>, IRestaurantTypeOfKitchenRepository
    {
        public RestaurantTypeOfKitchenRepository(WebApiContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
