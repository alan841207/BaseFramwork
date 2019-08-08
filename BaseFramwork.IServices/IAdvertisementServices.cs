using BaseFramwork.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramwork.IServices
{
    public interface IAdvertisementServices: IBaseServices<Advertisement>
    {
        Task<List<Advertisement>> GetBlogs();

        //int Sum(int i, int j);

        //int Add(Advertisement model);
        //bool Delete(Advertisement model);
        //bool Update(Advertisement model);
        //List<Advertisement> Query(Expression<Func<Advertisement, bool>> whereExpression);
    }
}
