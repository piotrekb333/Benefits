using Benefits.Models.Requests;
using Benefits.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Benefits.Controllers
{
    public class ClientObjectController : ApiController
    {
        private readonly IClientObjectService _clientObjectService;
        public ClientObjectController(IClientObjectService clientObjectService)
        {
            _clientObjectService = clientObjectService;
        }

        [HttpPost]
        [Route("api/clientobject/addClientToRestaurant")]
        public IHttpActionResult AddClientToRestaurant([FromBody]AddClientToRestaurantRequest model)
        {
            _clientObjectService.AddClientToRestaurant(model);
            return Ok();
        }

        [HttpPost]
        [Route("api/clientobject/addClientToGym")]
        public IHttpActionResult AddClientToGym([FromBody]AddClientToGymRequest model)
        {
            _clientObjectService.AddClientToGym(model);
            return Ok();
        }
    }
}