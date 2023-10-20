using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using onlineCourses.Repository;

namespace onlineCourses.Controllers
{
    [Authorize]
    public class StudentController : Controller
    {
        private readonly IStudentRopsitory _studentRepo;

        public StudentController(IStudentRopsitory studentRepo)
        {
            _studentRepo = studentRepo;
        }
        public IActionResult Details(string Name)
        {
            
           var s = _studentRepo.GetStudent(Name);

            return View(s);
        }

        public IActionResult AddCourse(string studentId, int courseId) 
        {
             _studentRepo.Enroll(studentId,courseId);
           
            return View();
        }
        public IActionResult Index()
        {
            var s = _studentRepo.GetAll();

            return View(s);
        }

        






    }
}
