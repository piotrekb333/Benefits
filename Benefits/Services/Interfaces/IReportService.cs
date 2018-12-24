using Benefits.Models.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benefits.Services.Interfaces
{
    public interface IReportService
    {
        List<ObjectsReportDto> GetObjectsReport(DateTime? dateFrom, DateTime? dateTo);
        List<ClientsReportDto> GetClientsReport(DateTime? dateFrom, DateTime? dateTo);
    }
}
