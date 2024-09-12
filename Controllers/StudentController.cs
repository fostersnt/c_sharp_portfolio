using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using students_api.data;
using students_api.DTO.studentDto;
using students_api.Mapper;
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

        public StudentController(ApplicationDBContext applicationDBContext)
        {
            _applicationDBContext = applicationDBContext;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var students = _applicationDBContext.students.ToList().Select(s => s.ResponseDto());

            if (students == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(students);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var student = _applicationDBContext.students.Find(id).ResponseDto();

            if (student == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(student);
            }
        }

        [HttpPost]
        public IActionResult PostStudent([FromBody] StudentRequestDto student)
        {
            var newStudent = student.RequestDto();

            if (student == null)
            {
                return BadRequest("Student data cannot be empty");
            }
            else
            {
                _applicationDBContext.students.Add(newStudent);
                _applicationDBContext.SaveChanges();
                return Ok(student);
            }
        }

    }
}
