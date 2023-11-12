using DataAccess;
using ObjectBussiness;

namespace Repository
{
    public class QuestionRepository : IQuestionRepository
    {
        public void DeleteQuestion(Question question) => QuestionDAO.Instance.DeleteQuestion(question);

        public IEnumerable<Question> GetQuestion() => QuestionDAO.Instance.GetQuestion();
        public Question GetQuestionById(int id) => QuestionDAO.Instance.GetQuestionById(id);

        public void InsertQuestion(Question question) => QuestionDAO.Instance.InsertQuestion(question);

        public void UpdateQuestion(Question question) => QuestionDAO.Instance.UpdateQuestion(question);
    }
}