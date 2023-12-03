using DataAccess;
using ObjectBussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class NewsRepository : INewsRepository
    {
        public void InsertNews(News n) => NewsDAO.Instance.InsertNews(n);
        public void EditNews(News n) => NewsDAO.Instance.EditNews(n);
        public void DeleteNews(int n) => NewsDAO.Instance.DeleteNews(n);
        public News GetNewsById(int id) => NewsDAO.Instance.GetNewsById(id);
        //public List<NewsCategory> GetNewsCategories() => NewsCategoryDAO.GetNewsCategories();
        public List<News> GetNewsList() => NewsDAO.Instance.GetNewsList();
    }
}
