using Microsoft.AspNetCore.Mvc;
using ObjectBussiness;
using Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionAPIController : ControllerBase
    {
        #region Variable
        private readonly IQuestionRepository questionRepository;
        private readonly Queue<Question> q = new Queue<Question>();
        private readonly IExamRepository examRepository;
        private readonly PetroleumBusinessDBContext db;
        private readonly IRoundRepository roundRepository;
        Queue<Question> questionQueue = new Queue<Question>();
        #endregion

        #region Constructor
        public QuestionAPIController()
        {
            roundRepository = new RoundRepository();
            db = new PetroleumBusinessDBContext();
            examRepository = new ExamRepository();
            questionRepository = new QuestionRepository();
        }
        #endregion

        #region API Get
        // GET: api/<QuestionAPIController>
        [HttpGet]
        public IEnumerable<Question> Get()
        {
            return questionRepository.GetQuestions();
        }
        #endregion

        #region API Search
        [Route("Search")]
        [HttpGet]
        public IEnumerable<Question> Search(string name, string? sortBy)
        {
            return questionRepository.SearchByNameOrSortBy(name, sortBy);
        }
        #endregion

        #region API Get {id}
        // GET api/<QuestionAPIController>/5
        [HttpGet("{id}")]
        public ActionResult<Question> Get(int id)
        {
            var check = questionRepository.GetQuestionById(id);
            if (check == null)
            {
                return NotFound();
            }
            return check;
        }
        #endregion

        #region API GetQuestionByRound
        [HttpGet("GetQuestionByExam/{id}")]
        public IEnumerable<Question> GetQuestionByRound(int id)
        {
            var check = questionRepository.GetQuestionsByRound(id);
            if (check != null)
            {
                return check;
            }
            return Enumerable.Empty<Question>();
        }
        #endregion

        #region API GetQueueQuestion
        [Route("GetQueueQuestion")]
        [HttpGet]
        public IEnumerable<Question> GetQueueQuestion(int score)
        {
            //PetroleumBusinessDBContext db = new PetroleumBusinessDBContext();
            //if (q.Count == 0)
            //{
            //    foreach (var item in db.Questions.ToList())
            //    {
            //        q.Enqueue(item);
            //    }
            //}
            //if (q.Count > 0)
            //{
            //    Question question = q.Dequeue();
            //    return question;
            //}
            //else
            //{
            //    return NotFound();
            //}
            var check = questionRepository.GetQuestions();
            if (check != null)
            {
                return check;
            }
            else
            {
                return Enumerable.Empty<Question>();
            }

        }
        #endregion

        #region API GetRoundID
        [Route("GetRoundID")]
        [HttpGet]
        public IEnumerable<Round> GetRoundID()
        {
            var rs = roundRepository.GetRoundId();
            return rs;
        }
        #endregion

        #region API POST
        // POST api/<QuestionAPIController>
        [HttpPost]
        public void Post(Question question)
        {
            questionRepository.InsertQuestion(question);
        }
        #endregion

        #region CheckAnswer
        [Route("CheckAnswer/{selectedAnswer}")]
        [HttpGet]
        public int CheckAnswer(string selectedAnswer)
        {
            Question question = new Question();
            int score = 0;
            string correctAnswer = "";

            //if (question.AnswerA != null)
            //{
            //    correctAnswer = "A";
            //}
            //if (question.AnswerB != null)
            //{
            //    correctAnswer = "B";
            //}
            //if (question.AnswerC != null)
            //{
            //    correctAnswer = "C";
            //}
            //if (question.AnswerD != null)
            //{
            //    correctAnswer = "D";
            //}

            //Queue<Question> q = new Queue<Question>();
            //PetroleumBusinessDBContext db = new PetroleumBusinessDBContext();
            //foreach (var item in db.Questions.ToList())
            //{
            //    q.Enqueue(item);
            //}
            //question = q.Peek();
            //q.Dequeue();

            //var result = questionRepository.GetCorrectAnswerBySelectAnswer(selectedAnswer);

            //if (result != null)
            //{
            //    return score += 1;
            //}
            score += 1;
            return score;
        }
        #endregion


        #region API PUT
        // PUT api/<QuestionAPIController>/5
        [HttpPut("{id}")]
        public void Put(Question question)
        {
            questionRepository.UpdateQuestion(question);
        }
        #endregion

        #region API Delete
        // DELETE api/<QuestionAPIController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            questionRepository.DeleteQuestion(id);
        }
        #endregion
    }
}
