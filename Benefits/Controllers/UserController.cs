using AutoMapper;
using Benefits.Models.Requests;
using Benefits.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Benefits.Controllers
{
    public class UserController : ApiController
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/user/authenticate")]
        public IHttpActionResult Authenticate([FromBody]AuthenticateRequest model)
        {
           var user = _userService.Authenticate(model.Username, model.Password);
            if (user == null)
                return BadRequest();
            return Ok(user);
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("api/user/create")]
        public IHttpActionResult Create([FromBody]AddUserRequest model)
        {
            _userService.Create(model);
            return Ok();
        }
    }
}