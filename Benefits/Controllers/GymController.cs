using Benefits.Models.DtoModels;
using Benefits.Models.Requests;
using Benefits.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Benefits.Controllers
{
    public class GymController : ApiController
    {
        private readonly IGymService _gymService;
        public GymController(IGymService gymService)
        {
            _gymService = gymService;
        }

        [HttpPost]
        [Route("api/gym/create")]
        [Authorize(Roles = "Admin")]
        public IHttpActionResult Create([FromBody]CreateGymRequest model)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            _gymService.Create(model);
            return Ok();
        }

        [HttpPut]
        [Route("api/gym/update")]
        public IHttpActionResult Update([FromBody]UpdateGymRequest model)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            _gymService.Update(model);
            return Ok();
        }

        [HttpDelete]
        [Route("api/gym/delete")]
        public IHttpActionResult Delete(int id)
        {
            _gymService.Delete(id);
            return Ok();
        }

        [HttpGet]
        [Route("api/gym/get")]
        public IHttpActionResult Get(int id)
        {
            var result=_gymService.GetById(id);
            return Ok<GymDto>(result);
        }

        [HttpGet]
        [Route("api/gym/getAll")]
        [Authorize]
        public IHttpActionResult GetAll()
        {
            var result = _gymService.GetAll();
            return Ok<List<GymDto>>(result);
        }
    }
}
