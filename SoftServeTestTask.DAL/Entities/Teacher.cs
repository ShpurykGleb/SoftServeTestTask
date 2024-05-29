using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using SoftServeTestTask.DAL.Entities.Contacts;
using SoftServeTestTask.DAL.Entities.Infoes;

namespace SoftServeTestTask.DAL.Entities
{
    public class Teacher
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int InfoId { get; set; }
        public TeacherInfoes? Info { get; set; }
        public int ContactsId { get; set; }
        public TeacherContacts? Contacts { get; set; }
        public string? AcademicDegree { get; set; }
        public int ExperienceYears { get; set; }
        public ICollection<Course>? Courses { get; set; }
    }
}
