using Microsoft.EntityFrameworkCore;
using ObjectBussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class NewsDAO
    {
        private static NewsDAO instance = null;
        public static readonly object instanceLock = new object();
        public static NewsDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new NewsDAO();
                    }
                    return instance;
                }
            }
        }
        public List<News> GetNewsList()
        {
            var list = new List<News>();
            try
            {
                using (var context = new PetroleumBusinessDBContext())
                {
                    list = context.News.ToList();
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            };
            return list;
        }

        public News GetNewsById(int id)
        {
            try
            {
                using (var context = new PetroleumBusinessDBContext())
                {
                    var check = context.News.FirstOrDefault(x => x.NewsID == id);
                    if (check != null)
                    {
                        return check;
                    }
                    throw new ArgumentException("News not found.");
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void InsertNews(News n)
        {
            try
            {
                using (var context = new PetroleumBusinessDBContext())
                {
                    context.News.Add(n);
                    context.SaveChanges();
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void EditNews(News n)
        {
            try
            {
                using (var context = new PetroleumBusinessDBContext())
                {
                    context.Entry<News>(n).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteNews(int n)
        {
            try
            {
                using (var context = new PetroleumBusinessDBContext())
                {
                    var check = GetNewsById(n);
                    if (check != null)
                    {
                        context.News.Remove(check);
                        context.SaveChanges();
                    }
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
