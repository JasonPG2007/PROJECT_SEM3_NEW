using DataAccess;
using ObjectBussiness;

namespace Repository
{
    public class QuestionRepository : IQuestionRepository
    {
        public void DeleteQuestion(Test question) => QuestionDAO.Instance.DeleteQuestion(question);

        public IEnumerable<Test> GetQuestion() => QuestionDAO.Instance.GetQuestion();
        public Test GetQuestionById(int id) => QuestionDAO.Instance.GetQuestionById(id);

        public void InsertQuestion(Test question) => QuestionDAO.Instance.InsertQuestion(question);

        public void UpdateQuestion(Test question) => QuestionDAO.Instance.UpdateQuestion(question);
    }
}