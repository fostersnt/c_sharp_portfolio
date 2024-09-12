using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using students_api.DTO.studentDto;
using students_api.models;

namespace students_api.Mapper;
// {
    public static class StudentMapper
    {
        //Extension method for student class
        public static StudentResponseDto ResponseDto(this Student student)
        {
            return new StudentResponseDto
            {
                id = student.id,
                name = student.name,
                age = student.age,
                status = student.status
            };
        }

    public static Student RequestDto(this StudentRequestDto studentRequestDto)
    {
        return new Student
        {
            name = studentRequestDto.name,
            age = studentRequestDto.age,
            status = studentRequestDto.status
        };
    }

    public static Student UpdateDto(this StudentUpdateDto studentUpdateDto)
    {
        return new Student
        {
            name = studentUpdateDto.name,
            age = studentUpdateDto.age,
            status = studentUpdateDto.status
        };
    }
}
// }