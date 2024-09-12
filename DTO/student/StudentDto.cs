using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace students_api.DTO.studentDto
{
    public class StudentResponseDto
    {
        public int id { get; set; }

        public string name { get; set; }

        public int age { get; set; }

        public string status { get; set; }
    }

    public class StudentRequestDto
    {
        public string name { get; set; }

        public int age { get; set; }

        public string status { get; set; }
    }

    public class StudentUpdateDto
    {
        public string name { get; set; }

        public int age { get; set; }

        public string status { get; set; }
    }
}