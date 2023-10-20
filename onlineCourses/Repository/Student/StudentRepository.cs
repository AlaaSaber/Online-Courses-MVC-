using Microsoft.EntityFrameworkCore;
using onlineCourses.Models;

namespace onlineCourses.Repository
{
    public class StudentRepository : IStudentRopsitory
    {
        private readonly DBContext _dbContext;

        public StudentRepository(DBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Enroll(string studentId,int? courseid)
        {
            var courses = new Student_Course();
                courses.Course_Id = courseid;
                courses.Stud_Id= studentId;
                var s = _dbContext.Student_Courses.Add(courses);
                _dbContext.SaveChanges();
        }

        public IEnumerable<Student> GetAll()
        {
           return _dbContext.Students.ToList();
        }

        public Student GetStudent(string name)
        {
            var student = _dbContext.Students.Where(s =>s.Name==name).FirstOrDefault();
            return student;
        }
    }
}
