using BaseFramwork.Common;
using BaseFramwork.IRepository;
using BaseFramwork.IServices;
using BaseFramwork.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class AdvertisementServices:BaseServices<Advertisement>,IAdvertisementServices
    {
        //IAdvertisementRepository dal = new AdvertisementRepository();


        IAdvertisementRepository dal;
        public AdvertisementServices(IAdvertisementRepository dal)
        {
            this.dal = dal;
            base.baseDal = dal;
        }


        /// <summary>
        /// 获取博客列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Caching(AbsoluteExpiration = 10)]//增加特性
        public async Task<List<Advertisement>> GetBlogs()
        {
            var bloglist = await dal.Query(a => a.Id == 1);

            return bloglist;

        }

        //public int Sum(int i, int j)
        //{
        //    return dal.Sum(i, j);
        //}
        //public int Add(Advertisement model)
        //{
        //    return dal.Add(model);
        //}

        //public bool Delete(Advertisement model)
        //{
        //    return dal.Delete(model);
        //}

        //public List<Advertisement> Query(Expression<Func<Advertisement, bool>> whereExpression)
        //{
        //    return dal.Query(whereExpression);

        //}

        //public bool Update(Advertisement model)
        //{
        //    return dal.Update(model);
        //}

    }
}
