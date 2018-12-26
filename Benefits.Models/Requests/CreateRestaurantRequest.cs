using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benefits.Models.Requests
{
    public class CreateRestaurantRequest
    {
        [Required]

        public string Name { get; set; }
        public int Rating { get; set; }
        [Required]

        public int CityId { get; set; }
        public List<int> TypeOfKitchens { get; set; }
    }
}
