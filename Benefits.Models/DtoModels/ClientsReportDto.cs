using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benefits.Models.DtoModels
{
    public class ClientsReportDto
    {
        public string Name { get; set; }
        public int NumberOfObjects { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
    }
}
