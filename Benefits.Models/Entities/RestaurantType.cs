using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benefits.DAL.Entities
{
    public class RestaurantType
    {
        public int Id { get; set; }
        public int TypeOfKitchenId { get; set; }
        public int RestaurantId { get; set; }
    }
}
