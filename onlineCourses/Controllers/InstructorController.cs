using Microsoft.AspNetCore.Mvc;
using onlineCourses.Repository.Courses;
using onlineCourses.Repository.InstructorRepo;
using onlineCourses.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using onlineCourses.Repository;
using onlineCourses.Data.Static;
using Microsoft.AspNetCore.Identity;

namespace onlineCourses.Controllers
{
    public class InstructorController : Controller
    {
        private readonly ICourseRepository CourseRepository;
        public readonly IInstructorRepository InstructorRepository;
        public readonly ICategoryRepository CategoryRepository;
        public static string Instructor_ID;

		public InstructorController( IInstructorRepository instructorRepository, ICourseRepository courseRepository, ICategoryRepository categoryRepository)
        {
            InstructorRepository = instructorRepository;
            CourseRepository = courseRepository;
			CategoryRepository = categoryRepository;
		}

        [Authorize(Roles = UserRoles.Instructor)]
        public IActionResult Home()
        {
            Claim idclaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            Instructor_ID = idclaim.Value;
            List<Course> courses = CourseRepository.GetCoursesByInstructorId(Instructor_ID);
            return View(courses);
        }


	}
}
