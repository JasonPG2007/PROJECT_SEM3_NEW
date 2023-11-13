using ObjectBussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ResultDAO
    {
        private static ResultDAO instance = null;
        private static readonly object Lock = new object();
        public static ResultDAO Instance
        {
            get
            {
                lock (Lock)
                {
                    if (instance == null)
                    {
                        instance = new ResultDAO();
                    }
                    return instance;
                }
            }
        }
        public IEnumerable<ResultOfCandidate> GetResults()
        {
            using var context = new PetroleumBusinessDBContext();
            var listResult = context.ResultOfCandidates.ToList();
            return listResult;
        }
        public ResultOfCandidate GetResultById(int id)
        {
            using var context = new PetroleumBusinessDBContext();
            var result = context.ResultOfCandidates.FirstOrDefault(r => r.ResultOfCandidateID == id);
            return result;
        }
        public void InsertResult(ResultOfCandidate result)
        {
            using var context = new PetroleumBusinessDBContext();
            var checkContains = GetResultById(result.ResultOfCandidateID);
            if (checkContains == null)
            {
                context.ResultOfCandidates.Add(result);
                context.SaveChanges();
            }
        }
        public void UpdateResult(ResultOfCandidate result)
        {
            using var context = new PetroleumBusinessDBContext();
            var checkContains = GetResultById(result.ResultOfCandidateID);
            if (checkContains != null)
            {
                context.Entry<ResultOfCandidate>(result).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
        }
        public void DeleteResult(ResultOfCandidate result)
        {
            using var context = new PetroleumBusinessDBContext();
            var checkContains = GetResultById(result.ResultOfCandidateID);
            if (checkContains != null)
            {
                context.ResultOfCandidates.Remove(result);
                context.SaveChanges();
            }
        }
    }
}
