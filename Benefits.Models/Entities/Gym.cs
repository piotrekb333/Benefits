using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Benefits.Models.Entities;

namespace Benefits.DAL.Entities
{
    public class Gym : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public bool IsPersonalTrainer { get; set; }
        public bool IsSauna { get; set; }
        public bool IsDietician { get; set; }
        [Required]
        public int CityId { get; set; }
        public virtual City City { get; set; }
        public virtual ICollection<Client> Clients { get; set; }

    }
}
