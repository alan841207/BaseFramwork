using AutoMapper;
using BaseFramwork.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseFramwork.Core
{
    public class CustomProfile:Profile
    {

        /// <summary>
        /// 配置构造函数，用来创建关系映射
        /// </summary>
        public CustomProfile()
        {
            CreateMap<BlogArticle, BlogViewModels>();
        }

    }
}
