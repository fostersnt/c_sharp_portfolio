using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace students_api.DTO.student
{
    public class StudentDto
    {
        public int id { get; set; }

        public String name { get; set; }

        public int age { get; set; }

        public String status { get; set; }
    }
}