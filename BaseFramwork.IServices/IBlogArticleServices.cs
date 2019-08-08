using BaseFramwork.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramwork.IServices
{
    public interface IBlogArticleServices:IBaseServices<BlogArticle>
    {
        Task<List<BlogArticle>> GetBlogs();
        Task<BlogViewModels> GetBlogDetails(int id);
    }
}
