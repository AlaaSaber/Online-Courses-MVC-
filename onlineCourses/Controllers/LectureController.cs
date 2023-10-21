using Microsoft.AspNetCore.Mvc;
using onlineCourses.Models;
using onlineCourses.Repository.Lectures;

namespace onlineCourses.Controllers
{
	public class LectureController : Controller
	{
		private ILectureRepository lectureRepository;

	
		public LectureController(ILectureRepository lectureRepository)
		{

			this.lectureRepository = lectureRepository;

		}

		#region GetALL
		public IActionResult Index()
		{
			return View(lectureRepository.getAllLectures());
		}
		#endregion


		#region New

		public IActionResult New() { 
		
		return View("New");
		}

		public IActionResult SaveNew(Lecture lec) {
		
			if(ModelState.IsValid)
			{
				lectureRepository.AddLecture(lec);
				lectureRepository.saveDB();
				return RedirectToAction("Index");
			}
			return View("New",lec);
		}

		#endregion

		#region Edit
		public IActionResult Edit(int id) { 
		
		Lecture model = lectureRepository.getLecByID(id);
			return View("Edit",model);
		
		}

		public IActionResult SaveEdit(Lecture lec) {
		
		if (ModelState.IsValid)
			{
				lectureRepository.UpdateLec(lec);
				lectureRepository.saveDB();
				return RedirectToAction("Index");
			}
			return View("Edit", lec);
		}


        #endregion

        #region Delete
        public IActionResult Delete(int id)
		{
			Lecture model = lectureRepository.getLecByID(id);

			if (model != null)
			{
			lectureRepository.DeleteLecture(model);
			return RedirectToAction("Index");
			}
			return View(model);

		}
        #endregion

    }
}
