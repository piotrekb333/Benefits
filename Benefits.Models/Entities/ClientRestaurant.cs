using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Benefits.DAL.Entities
{
    public class ClientRestaurant : BaseEntity
    {
        public DateTime Date { get; set; }
        public int ClientId { get; set; }
        public int RestaurantId { get; set; }
        public virtual Client Client { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }
}
