using DataAccess;
using ObjectBussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ResultRepository : IResultRepository
    {
        public void DeleteResult(ResultOfCandidate result) => ResultDAO.Instance.DeleteResult(result);
        public ResultOfCandidate GetResultById(int id) => ResultDAO.Instance.GetResultById(id);

        public IEnumerable<ResultOfCandidate> GetResults() => ResultDAO.Instance.GetResults();

        public void InsertResult(ResultOfCandidate result) => ResultDAO.Instance.InsertResult(result);

        public void UpdateResult(ResultOfCandidate result) => ResultDAO.Instance.UpdateResult(result);
    }
}
