using CustomLibrary.models;
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
            try {
                var students = _applicationDBContext.students.ToList().Select(s => s.ResponseDto());

                if (students == null)
                {
                    return NotFound(ApiResponseStructure.apiResponse(false, "Student cannot be found", null));
                }
                else
                {
                    return Ok(ApiResponseStructure.apiResponse(true, "Students found", students));
                }
            } catch (Exception ex) { 
                return BadRequest(ApiResponseStructure.apiResponse(false, ex.Message.ToString(), null));
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try {
                var student = _applicationDBContext.students.Find(id).ResponseDto();

                if (student == null)
                {
                    return NotFound(ApiResponseStructure.apiResponse(false, "Student not found", null));
                }
                else
                {
                    return Ok(ApiResponseStructure.apiResponse(true, "Student available", student));
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ApiResponseStructure.apiResponse(false, ex.Message.ToString(), null));
            }
        }

        [HttpPost]
        [Route("create")]
        public IActionResult PostStudent([FromBody] StudentRequestDto student)
        {
            var newStudent = student.RequestDto();

            if (student == null)
            {
                return BadRequest(ApiResponseStructure.apiResponse(false, "Student data cannot be empty", null));
            }
            else
            {
                _applicationDBContext.students.Add(newStudent);
                _applicationDBContext.SaveChanges();
                return Ok(ApiResponseStructure.apiResponse(true, "Student created successfully", student));
            }
        }

        [HttpPut]
        [Route("update/{id}")]
        public IActionResult updateStudent([FromRoute] int id, [FromBody] StudentUpdateDto studentUpdateDto)
        {
            try {
                var student = _applicationDBContext.students.Find(id);

                if (student == null)
                {
                    return Ok(ApiResponseStructure.apiResponse(false, $"Student with ID: {id} cannot be found", null));
                }
                else
                {
                    student.age = studentUpdateDto.age;
                    student.name = studentUpdateDto.name;
                    student.status = studentUpdateDto.status;

                    _applicationDBContext.SaveChanges();

                    return Ok(ApiResponseStructure.apiResponse(true, "Student has been updated successfully", studentUpdateDto));
                }
            } catch (Exception ex) { 
                return BadRequest(ApiResponseStructure.apiResponse(false, ex.Message.ToString(), null));
            }
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult DeleteStudent([FromRoute] int id) {
            try {
                var student = _applicationDBContext.students.Find(id);

                if (student == null)
                {
                    return Ok(ApiResponseStructure.apiDeleteResponse(false, $"Could not find student with ID: {id}"));
                }
                else
                {
                    _applicationDBContext.students.Remove(student);
                    _applicationDBContext.SaveChanges();
                    return Ok(ApiResponseStructure.apiDeleteResponse(true, "Student has been deleted successfully"));
                }
            } catch(Exception ex) {
                return BadRequest(ApiResponseStructure.apiDeleteResponse(false, ex.Message.ToString().ToString()));
            }
        }

    }
}
