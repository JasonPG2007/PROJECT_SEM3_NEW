using ObjectBussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IResultRepository
    {
        public IEnumerable<ResultOfCandidate> GetResults();
        public ResultOfCandidate GetResultById(int id);
        public void InsertResult(ResultOfCandidate result);
        public void UpdateResult(ResultOfCandidate result);
        public void DeleteResult(ResultOfCandidate result);
    }
}
