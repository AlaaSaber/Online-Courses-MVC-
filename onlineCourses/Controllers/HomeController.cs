using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using onlineCourses.Models;
using onlineCourses.Repository;

namespace onlineCourses.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        public HomeController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IActionResult> IndexAsync()
        {
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