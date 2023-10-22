using onlineCourses.Models;

namespace onlineCourses.Repository.Questions
{
    public class QuestionRepository : IQuestionRepository
    {
        private DBContext dBContext;

        public QuestionRepository(DBContext dBContext) 
        {
            this.dBContext = dBContext;
        }
        public void AddQuestion(Question question)
        {
            dBContext.Questions.Add(question);
        }

        public void DeleteQuestion(Question question)
        {
            dBContext.Questions.Remove(question);
        }

        public List<Question> getAllQuestions(int ExamID)
        {
            return dBContext.Questions.Where(q=>q.exam_id == ExamID).ToList();
        }

        public int saveDB()
        {
            return dBContext.SaveChanges();
        }

        public void UpdateQuestion(Question question)
        {
            dBContext.Questions.Update(question);
        }
    }
}
