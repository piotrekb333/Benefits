using Benefits.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benefits.DAL.Entities
{
    public class ClientGym : BaseEntity
    {
        public DateTime Date { get; set; }
        public int ClientId { get; set; }
        public int GymId { get; set; }
        public virtual Client Client { get; set; }
        public virtual Gym Gym { get; set; }
    }
}
