using onlineCourses.Models;

namespace onlineCourses.Repository.Courses
{
    public interface ICourseRepository
    {
        List<Course> getAllCourses ();
        Course getCourseByID (int ID);
        void UpdateCourse (Course course);
        void DeleteCourse (Course course);
        void AddCourse (Course course);
        int saveDB ();
    }
}
