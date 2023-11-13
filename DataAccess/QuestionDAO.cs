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
        public IEnumerable<Test> GetQuestion()
        {
            using var context = new PetroleumBusinessDBContext();
            var listQuestion = context.Testes.ToList();
            return listQuestion;
        }
        public Test GetQuestionById(int id)
        {
            using var context = new PetroleumBusinessDBContext();
            var question = context.Testes.FirstOrDefault(q => q.TestID == id);
            return question;
        }
        public void InsertQuestion(Test question)
        {
            using var context = new PetroleumBusinessDBContext();
            var checkContains = GetQuestionById(question.TestID);
            if (checkContains == null)
            {
                context.Testes.Add(question);
                context.SaveChanges();
            }
        }
        public void UpdateQuestion(Test question)
        {
            using var context = new PetroleumBusinessDBContext();
            var checkContains = GetQuestionById(question.TestID);
            if (checkContains != null)
            {
                context.Entry<Test>(question).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
        }
        public void DeleteQuestion(Test question)
        {
            using var context = new PetroleumBusinessDBContext();
            var checkContains = GetQuestionById(question.TestID);
            if (checkContains != null)
            {
                context.Testes.Remove(question);
                context.SaveChanges();
            }
        }
    }
}