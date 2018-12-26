using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benefits.DAL.Entities
{
    public class Restaurant : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public int Rating { get; set; }
        [Required]
        public int CityId { get; set; }
        public virtual City City { get; set; }
        public virtual ICollection<RestaurantTypeOfKitchen> RestaurantTypeOfKitchens { get; set; }
    }
}
