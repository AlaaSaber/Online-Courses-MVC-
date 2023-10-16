using Microsoft.AspNetCore.Mvc;
using onlineCourses.Repository.Courses;

namespace onlineCourses.Controllers
{
    public class CourseController : Controller
    {
        private ICourseRepository courseRepository;

        public CourseController(ICourseRepository courseRepository)
        {
            this.courseRepository = courseRepository;
        }
        public IActionResult Index()
        {
            return View(courseRepository.getAllCourses());
        }
    }
}
