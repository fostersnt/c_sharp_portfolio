using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using students_api.data;
using students_api.models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace students_api.Controllers
{
    // [Route("api/[controller]")]
    [Route("api/student")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ApplicationDBContext _applicationDBContext;

        // GET: api/<ValuesController>
        public StudentController(ApplicationDBContext applicationDBContext)
        {
            _applicationDBContext = applicationDBContext;
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            var availableClasses = _applicationDBContext.availableClasses.ToList();
            
            return Ok(availableClasses);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var availableClass = _applicationDBContext.availableClasses.Find(id);
            return Ok(availableClass);
        }

        // public IActionResult GetById([FromRoute] int id)
        // {
        //     var availableClass = _applicationDBContext.availableClasses.Find(id);
        //     return Ok(id);
        // }

    }
}
