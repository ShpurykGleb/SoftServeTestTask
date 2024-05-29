using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using SoftServeTestTask.DAL.Entities.Contacts;
using SoftServeTestTask.DAL.Entities.Infoes;

namespace SoftServeTestTask.DAL.Entities
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int InfoId { get; set; }
        public StudentInfoes? Info { get; set; }
        public int ContactsId { get; set; }
        public StudentContacts? Contacts { get; set; }
        public decimal GPA { get; set; }
        public string? Group { get; set; }
        public ICollection<Course>? Courses { get; set; }
    }
}
