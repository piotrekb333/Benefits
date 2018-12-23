using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benefits.Models.Requests
{
    public class CreateRestaurantRequest
    {
        public string Name { get; set; }
        public int Rating { get; set; }
        public int CityId { get; set; }
        public List<int> TypeOfKitchens { get; set; }
    }
}
