using onlineCourses.Models;

namespace onlineCourses.Repository.Courses
{
    public class CourseRepository : ICourseRepository
    {
        private DBContext dBContext;

        public CourseRepository(DBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        public void AddCourse(Course course)
        {
            dBContext.Add(course);
        }

        public void DeleteCourse(Course course)
        {
            dBContext.Remove(course);
        }

        public List<Course> getAllCourses()
        {
            return dBContext.Courses.ToList();
        }

        public Course getCourseByID(int ID)
        {
            return dBContext.Courses.Where(c => c.Id == ID).FirstOrDefault();
        }

        public int saveDB()
        {
            return dBContext.SaveChanges();
        }

        public void UpdateCourse(Course course)
        {
            dBContext.Update(course);
        }
    }
}
