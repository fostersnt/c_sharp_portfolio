using System.ComponentModel.DataAnnotations;

namespace students_api.models
{
    public class Student
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Student name cannot be blank")]
        public String name { get; set; }

        [Required(ErrorMessage = "Age is required")]
        public int age { get; set; }

        [Required(ErrorMessage = "Status is required")]
        public String status { get; set; }

        [Required(ErrorMessage = "Class is a required field")]
        public String currentClass { get; set; }
    }
}
