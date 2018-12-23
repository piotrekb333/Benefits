using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Benefits.Models.ConfigurationModels.Enum;

namespace Benefits.DAL.Entities
{
    public class ClientObject
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int ClientId { get; set; }
        public ObjectType ObjectType { get; set; }
    }
}
