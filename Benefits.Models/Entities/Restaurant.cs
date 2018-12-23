using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Benefits.Models.Entities;

namespace Benefits.DAL.Entities
{
    public class Restaurant : BaseEntity
    {
        public string Name { get; set; }
        public int Rating { get; set; }
        public int CityId { get; set; }
    }
}
