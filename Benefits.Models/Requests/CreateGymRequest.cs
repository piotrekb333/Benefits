using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benefits.Models.Requests
{
    public class CreateGymRequest
    {
        public string Name { get; set; }
        public bool IsPersonalTrainer { get; set; }
        public bool IsSauna { get; set; }
        public bool IsDietician { get; set; }
        public int CityId { get; set; }
    }
}
