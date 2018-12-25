using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benefits.Models.DtoModels
{
    public class RestaurantDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Rating { get; set; }
        public int CityId { get; set; }
        public string CityName { get; set; }
        public List<TypeOfKitchenDto> TypeOfKitchenDto { get; set; }
    }
}
