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
        [Range(1, 18, ErrorMessage = "Age should be between 1 and 18")]
        public int age { get; set; }

        [Required(ErrorMessage = "Status is required")]
        public String status { get; set; }

        [Required(ErrorMessage = "Class is a required field")]
        [StringLength(30, ErrorMessage = "Class should be between 1 and 30 characters")]
        public String currentClass { get; set; }
    }
}
