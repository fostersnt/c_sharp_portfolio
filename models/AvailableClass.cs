using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace students_api.models
{
    public class AvailableClass
    {
        public int Id { get; set; }
        public string name { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public DateTime UpdateAt { get; set; } = DateTime.Now;
        public ICollection<Student> Students { get; set; }
    }
}