﻿using BlogForest.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogForest.DataAccessLayer.Abstract
{
    public interface IBlogDal : IGenericDal<Blog>
    {
        List<Blog> GetBlogsWithCategoryAndUser();
        List<Blog> GetLast2BlogByUser(int id);
        List<Blog> GetBlogByAppUser ( int id );
        void IncreaseBlogViewCount ( int id );
    }
}
