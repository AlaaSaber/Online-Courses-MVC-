using onlineCourses.Controllers;
using onlineCourses.Models;
using onlineCourses.Models.Attributes;
namespace onlineCourses.Repository

{
    public interface IStudentRopsitory
    {
         void Enroll(string studentId, int? courseid);
         IEnumerable<Student> GetAll(); 

        Student GetStudent(string name);

    }
}
