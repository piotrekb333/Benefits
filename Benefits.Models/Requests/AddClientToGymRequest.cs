using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benefits.Models.Requests
{
    public class AddClientToGymRequest
    {
        public DateTime Date { get; set; }
        public int ClientId { get; set; }
        public int GymId { get; set; }
    }
}
