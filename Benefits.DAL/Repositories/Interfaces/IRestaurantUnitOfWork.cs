using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benefits.DAL.Repositories.Interfaces
{
    public interface IRestaurantUnitOfWork
    {
        void CommitTransaction();
        void BeginTransaction();
        void RollbackTransaction();
        IRestaurantRepository GetRestaurantRepository();
        IRestaurantTypeOfKitchenRepository GetRestaurantTypeRepository();
    }
}
