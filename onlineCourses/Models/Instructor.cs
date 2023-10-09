using System.ComponentModel.DataAnnotations.Schema;

namespace onlineCourses.Models
{
    public class Instructor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int age { get; set; }
        public string address { get; set; }
        public byte[] image { get; set; }
        public Char gender { get; set; }
        public int phone { get; set; }
        public bool IsDeleted { get; set; }
        public virtual ICollection<Course>? Courses { get; set; }
        public virtual ICollection<Lecture>? Lectures { get; set; }


    }
}

