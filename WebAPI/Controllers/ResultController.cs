using Microsoft.AspNetCore.Mvc;
using ObjectBussiness;
using Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultController : ControllerBase
    {
        private IResultRepository _resultRepository;
        public ResultController()
        {
            _resultRepository = new ResultRepository();
        }
        // GET: api/<ResultController>
        [HttpGet]
        public IEnumerable<ResultOfCandidate> Get()
        {
            return _resultRepository.GetResults();
        }

        // GET api/<ResultController>/5
        [HttpGet("{id}")]
        public ResultOfCandidate Get(int id)
        {
            var checkContains = _resultRepository.GetResultById(id);
            return checkContains;
        }

        // POST api/<ResultController>
        [HttpPost]
        public void Post(ResultOfCandidate result)
        {
            _resultRepository.InsertResult(result);
        }

        // PUT api/<ResultController>/5
        [HttpPut("{id}")]
        public void Put(ResultOfCandidate result)
        {
            _resultRepository.UpdateResult(result);
        }

        // DELETE api/<ResultController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var checkContains = _resultRepository.GetResultById(id);
            if (checkContains != null)
            {
                _resultRepository.DeleteResult(checkContains);
            }
        }
    }
}
