using Benefits.Models.DtoModels;
using Benefits.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Benefits.Controllers
{
    public class ReportController : ApiController
    {
        private readonly IReportService _reportService;
        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet]
        [Route("api/report/objectsReport")]
        public IHttpActionResult ObjectsReport(DateTime? dateFrom = null,DateTime? dateTo = null)
        {
            var result = _reportService.GetObjectsReport(dateFrom,dateTo);
            return Ok<List<ObjectsReportDto>>(result);
        }

        [HttpGet]
        [Route("api/report/clientsReport")]
        public IHttpActionResult ClientsReport(DateTime? dateFrom = null, DateTime? dateTo = null)
        {
            var result = _reportService.GetClientsReport(dateFrom, dateTo);
            return Ok<List<ClientsReportDto>>(result);
        }

    }
}