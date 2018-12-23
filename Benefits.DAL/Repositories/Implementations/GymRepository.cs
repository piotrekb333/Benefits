using Benefits.DAL.Context;
using Benefits.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benefits.DAL.Repositories.Implementations
{
    public class GymRepository : RepositoryBase<Gym>, IGymRepository
    {
        public GymRepository(WebApiContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
