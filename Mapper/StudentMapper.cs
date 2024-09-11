using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using students_api.DTO.student;
using students_api.models;

namespace students_api.Mapper
{
    public static class StudentMapper
    {
        public static StudentDto ToDTO(this Student student)
        {
            return new StudentDto
            {
                id = student.id,
                name = student.name,
                age = student.age,
                status = student.status
            };

        }
    }
}