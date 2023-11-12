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
        public IEnumerable<Result> GetResults();
        public Result GetResultById(int id);
        public void InsertResult(Result result);
        public void UpdateResult(Result result);
        public void DeleteResult(Result result);
    }
}
