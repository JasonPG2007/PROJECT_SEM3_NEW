using ObjectBussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IQuestionRepository
    {
        public IEnumerable<Test> GetQuestion();
        public Test GetQuestionById(int id);
        public void InsertQuestion(Test question);
        public void UpdateQuestion(Test question);
        public void DeleteQuestion(Test question);
    }
}
