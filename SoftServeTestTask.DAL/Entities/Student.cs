using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SoftServeTestTask.DAL.Entities
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Age { get; set; }
        public string? FirstName { get; set; }
        public string? SecondName { get; set; }
        public string? ThirdName { get; set; }
        public string? Gender { get; set; }
        public decimal GPA { get; set; }
        public string? Group { get; set; }
        public ICollection<Course>? Courses { get; set; }
    }
}
