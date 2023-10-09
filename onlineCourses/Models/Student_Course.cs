using System.ComponentModel.DataAnnotations.Schema;

namespace onlineCourses.Models
{
    public class Student_Course
    {
        [ForeignKey("Student")]
        public int? Stud_Id { get; set; }

        [ForeignKey("Course")]
        public int? Course_Id { get; set; }
        public int degree { get; set; }
        public virtual Student? Student { get; set; }
        public virtual Course? Course { get; set; }

    }
}
