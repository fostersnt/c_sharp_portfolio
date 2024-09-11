using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace students_api.DTO.student
{
    public class StudentDto
    {
        public int id { get; set; }

        public string name { get; set; }

        public int age { get; set; }

        public string status { get; set; }
    }
}