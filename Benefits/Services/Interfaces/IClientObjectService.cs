using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benefits.Services.Interfaces
{
    public interface IClientObjectService
    {
        void Create();
        void Update(int id);
        void Delete(int id);
        
    }
}
