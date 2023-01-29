using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using StoriesManagement.Models;

namespace StoriesManagement.Services
{
    public class ArticlesService : IArticlesService
    {
        private readonly DBContext _dbContext;

        public ArticlesService(DBContext dBContext)
        {
            _dbContext = dBContext;
        }

        public async Task<Article[]> GetArticles(int? categoryId = null)
        {
            Article[] res;

            var result = _dbContext.Articles.Select(ar => new Article
            {
                IsFavorite = _dbContext.Favorites.Where(x => x.ArticleId == ar.Id).Any() ? true : false,
                CategoryId = ar.CategoryId,
                Description = ar.Description,
                Id = ar.Id,
                Image = ar.Image,
                Title = ar.Title
            });


            if (categoryId.HasValue)
            {
                res = result.Where(article => article.CategoryId == categoryId.Value).ToArray();
            }
            else
            {
                res = result.ToArray();

            }
            return res;
        }

        public async Task<Category[]> GetCategories()
        {
            return _dbContext.Categories.ToArray();
        }


    }

}
