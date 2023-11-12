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
        public IEnumerable<Result> GetResults()
        {
            using var context = new ProjectDBContext();
            var listResult = context.Results.ToList();
            return listResult;
        }
        public Result GetResultById(int id)
        {
            using var context = new ProjectDBContext();
            var result = context.Results.FirstOrDefault(r => r.ResultId == id);
            return result;
        }
        public void InsertResult(Result result)
        {
            using var context = new ProjectDBContext();
            var checkContains = GetResultById(result.ResultId);
            if (checkContains == null)
            {
                context.Results.Add(result);
                context.SaveChanges();
            }
        }
        public void UpdateResult(Result result)
        {
            using var context = new ProjectDBContext();
            var checkContains = GetResultById(result.ResultId);
            if (checkContains != null)
            {
                context.Entry<Result>(result).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
        }
        public void DeleteResult(Result result)
        {
            using var context = new ProjectDBContext();
            var checkContains = GetResultById(result.ResultId);
            if (checkContains != null)
            {
                context.Results.Remove(result);
                context.SaveChanges();
            }
        }
    }
}
