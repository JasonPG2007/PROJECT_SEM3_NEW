using ObjectBussiness;

namespace DataAccess
{
    public class QuestionDAO
    {
        private static QuestionDAO instance = null;
        private static readonly object Lock = new object();
        public static QuestionDAO Instance
        {
            get
            {
                lock (Lock)
                {
                    if (instance == null)
                    {
                        instance = new QuestionDAO();
                    }
                    return instance;
                }
            }
        }
        public IEnumerable<Question> GetQuestion()
        {
            using var context = new ProjectDBContext();
            var listQuestion = context.Questions.ToList();
            return listQuestion;
        }
        public Question GetQuestionById(int id)
        {
            using var context = new ProjectDBContext();
            var question = context.Questions.FirstOrDefault(q => q.QuestionId == id);
            return question;
        }
        public void InsertQuestion(Question question)
        {
            using var context = new ProjectDBContext();
            var checkContains = GetQuestionById(question.QuestionId);
            if (checkContains == null)
            {
                context.Questions.Add(question);
                context.SaveChanges();
            }
        }
        public void UpdateQuestion(Question question)
        {
            using var context = new ProjectDBContext();
            var checkContains = GetQuestionById(question.QuestionId);
            if (checkContains != null)
            {
                context.Entry<Question>(question).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
        }
        public void DeleteQuestion(Question question)
        {
            using var context = new ProjectDBContext();
            var checkContains = GetQuestionById(question.QuestionId);
            if (checkContains != null)
            {
                context.Questions.Remove(question);
                context.SaveChanges();
            }
        }
    }
}