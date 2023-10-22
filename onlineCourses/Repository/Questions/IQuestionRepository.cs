using onlineCourses.Models;

namespace onlineCourses.Repository.Questions
{
    public interface IQuestionRepository
    {
        List<Question> getAllQuestions(int ExamID);
        void UpdateQuestion(Question question);
        void DeleteQuestion(Question question);
        void AddQuestion(Question question);
        int saveDB();
    }
}
