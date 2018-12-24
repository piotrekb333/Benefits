using Benefits.DAL.Context;
using Benefits.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benefits.DAL.Repositories.Implementations
{
    public class RestaurantUnitOfWork : IRestaurantUnitOfWork
    {
        private readonly WebApiContext _context;
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IRestaurantTypeRepository _restaurantTypeRepository;
        public RestaurantUnitOfWork(WebApiContext repositoryContext)
        {
            _context = repositoryContext;
            _restaurantRepository = new RestaurantRepository(_context);
            _restaurantTypeRepository = new RestaurantTypeRepository(_context);
        }

        public IRestaurantRepository GetRestaurantRepository()
        {
            return _restaurantRepository;
        }
        public IRestaurantTypeRepository GetRestaurantTypeRepository()
        {
            return _restaurantTypeRepository;
        }
        public void BeginTransaction()
        {
            _context.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            _context.Database.CurrentTransaction?.Commit();
        }

        public void RollbackTransaction()
        {
            _context.Database.CurrentTransaction?.Rollback();
        }
    }
}
