using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benefits.DAL.Entities
{
    public class RestaurantTypeOfKitchen : BaseEntity
    {
        public int TypeOfKitchenId { get; set; }
        public int RestaurantId { get; set; }

        public virtual Restaurant Restaurant { get; set; }
        public virtual TypeOfKitchen TypeOfKitchen { get; set; }

    }
}
