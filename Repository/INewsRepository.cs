using ObjectBussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface INewsRepository
    {
        void InsertNews(News n);
        void EditNews(News n);
        void DeleteNews(int n);
        News GetNewsById(int id);
        //List<NewsCategory> GetNewsCategories();
        List<News> GetNewsList();

    }
}
