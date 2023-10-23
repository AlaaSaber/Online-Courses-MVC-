using Microsoft.AspNetCore.Mvc;
using onlineCourses.Data.ViewModels.CourseViewModels;
using onlineCourses.Models;
using onlineCourses.Repository;
using onlineCourses.Repository.Courses;

namespace onlineCourses.Controllers
{
    public class CourseController : Controller
	{
		private ICourseRepository courseRepository;
		private ICategoryRepository categoryRepository;

		public CourseController(ICourseRepository courseRepository, ICategoryRepository categoryRepository)
		{
			this.courseRepository = courseRepository;
			this.categoryRepository = categoryRepository;
		}
		public IActionResult Index()
		{
			ViewBag.cats =  categoryRepository.GetAll();
			return View(courseRepository.getAllCourses());
		}	
		public IActionResult getCoursesByCategory(int CatID)
		{
			if (CatID == 0)
			{
				var courses = courseRepository.getAllCourses().Select(x => new {
					x.Id,
					x.Title,
					x.Description,
					x.Grade,
					x.Name
				});
				return Json(courses);
			}
			else
			{
				var courses = courseRepository.getCourseByCategotyID(CatID).Select(x => new {
					x.Id,
					x.Title,
					x.Description,
					x.Grade,
					x.Name
				});

				return Json(courses);
			}
		}
		public async Task<IActionResult> CourseDetails(int id)
		{
			return View( courseRepository.getCourseByID(id));
		}
		[HttpGet]
		public IActionResult NewCourse()
		{
			ViewBag.cats = categoryRepository.GetAll();
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult NewCourse(AddCourseModel addCourseModel)
		{
			if (ModelState.IsValid)
			{
				Course course = new Course();
				course.Name = addCourseModel.Name;
				course.Title = addCourseModel.Title;
				course.Description = addCourseModel.Description;
				course.price = addCourseModel.price;
				course.Duration = addCourseModel.Duration;
				course.Grade = addCourseModel.Grade;
				course.Created = DateTime.Now;
				course.IsDeleted = false;
				course.cat_id = addCourseModel.categoryID;
				courseRepository.AddCourse(course);
				courseRepository.saveDB();
				return RedirectToAction("index");
			}
			return View(addCourseModel);
		}

		[HttpGet]
		public IActionResult EditCourse(int id)
		{
			Course course = courseRepository.getCourseByID(id);
			AddCourseModel addCourseModel = new AddCourseModel();
			addCourseModel.Name = course.Name;
			addCourseModel.Title = course.Title;
			addCourseModel.Description = course.Description;
			addCourseModel.price = course.price;
			addCourseModel.Duration = course.Duration;
			addCourseModel.Grade = course.Grade;
			addCourseModel.categoryID = course.cat_id ?? 0;

			ViewBag.id = id;

			ViewBag.cats = categoryRepository.GetAll();

			return View(addCourseModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult EditCourse(AddCourseModel addCourseModel, int id)
		{
			if (ModelState.IsValid)
			{
				Course course = courseRepository.getCourseByID(id);
				course.Name = addCourseModel.Name;
				course.Title = addCourseModel.Title;
				course.Description = addCourseModel.Description;
				course.price = addCourseModel.price;
				course.Duration = addCourseModel.Duration;
				course.Grade = addCourseModel.Grade;
				course.cat_id = addCourseModel.categoryID;
				courseRepository.UpdateCourse(course);
				courseRepository.saveDB();
				return RedirectToAction("index");
			}
			ViewBag.cats = categoryRepository.GetAll();
			return View(addCourseModel);
		}

		public ActionResult DeleteCourse(int id)
		{
			Course course = courseRepository.getCourseByID(id);
			course.IsDeleted = true;
			courseRepository.UpdateCourse(course);
			courseRepository.saveDB();
			return RedirectToAction("index");
		}

	}
}
