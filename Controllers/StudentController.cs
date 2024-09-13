using CustomLibrary.interfaces;
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
        private readonly IDatabaseCRUD<Student> _databaseCRUD;

        public StudentController(ApplicationDBContext applicationDBContext, IDatabaseCRUD<Student> databaseCRUD)
        {
            _applicationDBContext = applicationDBContext;
            _databaseCRUD = databaseCRUD;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var students = await _databaseCRUD.GetAllAsync();

            //Filtering for only the needed fields of the student object
            var finalStudents = students.Select(s => s.ResponseDto());


            string message = "";

            if (students == null)
            {
                message = "No students found";
            }
            else
            {
                message = "Students found";
            }

            return Ok(ApiResponseStructure.apiResponse(true, message, finalStudents));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try {
                var student = await _applicationDBContext.students.FindAsync(id);

                if (student == null)
                {
                    return NotFound(ApiResponseStructure.apiResponse(true, "Student not found", null));
                }
                else
                {
                    var currentStudent = student.ResponseDto();

                    return Ok(ApiResponseStructure.apiResponse(true, "Student available", currentStudent));
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ApiResponseStructure.apiResponse(false, ex.Message.ToString(), null));
            }
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> PostStudent([FromBody] StudentRequestDto student)
        {
            var newStudent = student.RequestDto();

            if (student == null)
            {
                return BadRequest(ApiResponseStructure.apiResponse(false, "Student data cannot be empty", null));
            }
            else
            {
                var createdStudent = await _applicationDBContext.students.AddAsync(newStudent);
              await _applicationDBContext.SaveChangesAsync();

                var newData = new StudentResponseDto {id = createdStudent.Entity.id, age = student.age, name = student.name, status = student.status };

                return Ok(ApiResponseStructure.apiResponse(true, "Student created successfully", newData));
            }
        }

        [HttpPut]
        [Route("update/{id}")]
        public async Task<IActionResult> updateStudent([FromRoute] int id, [FromBody] StudentUpdateDto studentUpdateDto)
        {
            try {
                var student = await _applicationDBContext.students.FindAsync(id);

                if (student == null)
                {
                    return Ok(ApiResponseStructure.apiResponse(false, $"Student with ID: {id} cannot be found", null));
                }
                else
                {
                    student.age = studentUpdateDto.age;
                    student.name = studentUpdateDto.name;
                    student.status = studentUpdateDto.status;

                   await _applicationDBContext.SaveChangesAsync();

                    return Ok(ApiResponseStructure.apiResponse(true, "Student has been updated successfully", studentUpdateDto));
                }
            } catch (Exception ex) { 
                return BadRequest(ApiResponseStructure.apiResponse(false, ex.Message.ToString(), null));
            }
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> DeleteStudent([FromRoute] int id) {
            try {
                var student = await _applicationDBContext.students.FindAsync(id);

                if (student == null)
                {
                    return Ok(ApiResponseStructure.apiDeleteResponse(false, $"Could not find student with ID: {id}"));
                }
                else
                {
                    _applicationDBContext.students.Remove(student);
                   await _applicationDBContext.SaveChangesAsync();
                    return Ok(ApiResponseStructure.apiDeleteResponse(true, "Student has been deleted successfully"));
                }
            } catch(Exception ex) {
                return BadRequest(ApiResponseStructure.apiDeleteResponse(false, ex.Message.ToString().ToString()));
            }
        }

    }
}
