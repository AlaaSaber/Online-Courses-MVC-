namespace onlineCourses.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public byte[] Image { get; set; }
        public Char Gender{ get; set; }
        public int Phone { get; set; }
        public bool IsDeleted { get; set; }
        public virtual ICollection<Student_Course>? Student_Course { get; set; }

    }
}
