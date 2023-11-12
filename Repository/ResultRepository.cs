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
        public void DeleteResult(Result result) => ResultDAO.Instance.DeleteResult(result);
        public Result GetResultById(int id) => ResultDAO.Instance.GetResultById(id);

        public IEnumerable<Result> GetResults() => ResultDAO.Instance.GetResults();

        public void InsertResult(Result result) => ResultDAO.Instance.InsertResult(result);

        public void UpdateResult(Result result) => ResultDAO.Instance.UpdateResult(result);
    }
}
