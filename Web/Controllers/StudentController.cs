using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet("name/{name}")]
        public IActionResult GetByName([FromRoute] string name)
        {
            return Ok(_studentService.Get(name));
        }


        //[HttpGet("{id}")]

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_studentService.Get());
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id) 
        {
            return Ok(_studentService.GetById(id));
        }

    }
}
