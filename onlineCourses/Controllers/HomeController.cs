using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using onlineCourses.Models;
using onlineCourses.Repository;

namespace onlineCourses.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
		public static string Instructor_ID;

		public HomeController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IActionResult> Index()
        {
			Claim idclaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
			Instructor_ID = idclaim?.Value;
			var categories = _categoryRepository.GetAll();
            ViewBag.coursesCount = await _categoryRepository.CategoryCoursesCount();
            return View(categories);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}