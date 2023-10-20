﻿using onlineCourses.Models;

namespace onlineCourses.Repository.Exams
{
    public interface IExamRepository
    {
        List<Exam> getExamByName (string Name);
		List<Exam> getExamByCourseID (int ID);
		void UpdateExam (Exam exam);
        void DeleteExam (Exam exam);
        void AddExam (Exam exam);
        int saveDB ();
    }
}
