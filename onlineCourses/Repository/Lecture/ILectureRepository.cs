using onlineCourses.Models;

namespace onlineCourses.Repository.Lectures
{
	public interface ILectureRepository
	{
		void AddLecture(Lecture lecture);
		void DeleteLecture(Lecture lecture);
		List<Lecture> getAllLectures();
		Lecture getLecByID(int ID);
		int saveDB();
		void UpdateLec(Lecture lecture);
	}
}