﻿using BaseFramwork.IRepository;
using BaseFramwork.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class BlogArticleRepository : BaseRepository<BlogArticle>, IBlogArticleRepository
    {
    }
}
