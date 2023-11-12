using Microsoft.AspNetCore.Mvc;
using ObjectBussiness;
using Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private QuestionRepository questionRepository;
        public QuestionController()
        {
            questionRepository = new QuestionRepository();
        }
        // GET: api/<QuestionAPIController>
        [HttpGet]
        public IEnumerable<Question> Get()
        {
            return questionRepository.GetQuestion();
        }

        // GET api/<QuestionAPIController>/5
        [HttpGet("{id}")]
        public Question Get(int id)
        {
            var question = questionRepository.GetQuestionById(id);
            return question;
        }

        // POST api/<QuestionAPIController>
        [HttpPost]
        public void Post(Question question)
        {
            questionRepository.InsertQuestion(question);
        }

        // PUT api/<QuestionAPIController>/5
        [HttpPut("{id}")]
        public void Put(Question question)
        {
            questionRepository.UpdateQuestion(question);
        }

        // DELETE api/<QuestionAPIController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var checkContains = questionRepository.GetQuestionById(id);
            if (checkContains != null)
            {
                questionRepository.DeleteQuestion(checkContains);
            }
        }
    }
}
