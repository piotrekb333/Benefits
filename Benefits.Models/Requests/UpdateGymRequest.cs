using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benefits.Models.Requests
{
    public class UpdateGymRequest
    {
        public int Id { get; set; }
        [Required]

        public string Name { get; set; }
        public bool IsPersonalTrainer { get; set; }
        public bool IsSauna { get; set; }
        public bool IsDietician { get; set; }
        [Required]

        public int CityId { get; set; }

    }
}
