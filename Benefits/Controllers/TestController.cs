using Benefits.DAL.Repositories.Interfaces;
using Benefits.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Benefits.Controllers
{
    public class TestController : ApiController
    {
        public TestController(IUserRepository t)
        {
            var d = t;
        }
        [HttpGet]
        [Route("api/test/getAll")]
        public IHttpActionResult GetAll()
        {
            var result = new List<string> { "test" };
            return Ok<List<string>>(result);
        }
    }
}