using BlogForest.DataAccessLayer.Abstract;
using BlogForest.DataAccessLayer.Context;
using BlogForest.DataAccessLayer.Repositories;
using BlogForest.DtoLayer.CategoryDtos;
using BlogForest.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogForest.DataAccessLayer.EntityFramework
{
    public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
    {
        public EfCategoryDal ( BlogContext context ) : base(context)
        {
        }

        public List<ResultCategoryWithCountDto> GetCategoryWithCount ()
        {
            var context = new BlogContext();
            var categoryBlogCounts= context.Categories.Select(x => new ResultCategoryWithCountDto
            {
                CategoryName = x.CategoryName,
                CategoryCount = x.Blogs.Count
            }).ToList();
            return categoryBlogCounts;
        }
    }
}