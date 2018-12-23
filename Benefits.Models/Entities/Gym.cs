using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benefits.DAL.Repositories
{
    public class Gym
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsPersonalTrainer { get; set; }
        public bool IsSauna { get; set; }
        public bool IsDietician { get; set; }
        public int CityId { get; set; }
    }
}
