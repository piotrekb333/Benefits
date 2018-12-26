using Benefits.Models.DtoModels;
using Benefits.Models.Requests;
using Benefits.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Benefits.Controllers
{
    public class RestaurantController : ApiController
    {
        private readonly IRestaurantService _restaurantService;
        public RestaurantController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        [HttpPost]
        [Route("api/restaurant/create")]
        public IHttpActionResult Create([FromBody]CreateRestaurantRequest model)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            _restaurantService.Create(model);
            return Ok();
        }

        [HttpPut]
        [Route("api/restaurant/update")]
        public IHttpActionResult Update([FromBody]UpdateRestaurantRequest model)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            _restaurantService.Update(model);
            return Ok();
        }

        [HttpDelete]
        [Route("api/restaurant/delete/{id}")]
        public IHttpActionResult Delete(int id)
        {
            _restaurantService.Delete(id);
            return Ok();
        }

        [HttpGet]
        [Route("api/restaurant/get/{id}")]
        public IHttpActionResult Get(int id)
        {
            var result = _restaurantService.GetById(id);
            return Ok<RestaurantDto>(result);
        }

        [HttpGet]
        [Route("api/restaurant/getAll")]
        public IHttpActionResult GetAll()
        {
            var result = _restaurantService.GetAll();
            return Ok<List<RestaurantDto>>(result);
        }
    }
}