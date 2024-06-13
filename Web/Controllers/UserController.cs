using Application.Services;
using Application.Interfaces;
using Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Models.Request;
using Domain.Entities;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
           _userService = userService;
        }

        [HttpGet ("{name}")]
         public IActionResult Get([FromRoute]string name)
        {
            return Ok(_userService.Get(name));
        }


        //[HttpGet("{id}")]
        //public IActionResult GetById([FromRoute] int id)
        //{
        //    return Ok(_userService.GetByID(id));
        //}

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok (_userService.GetAll());
        }

        [HttpPost]
        public IActionResult Add([FromBody] User user)
        {
            return Ok(_userService.Add(user));
        }

    }
}
