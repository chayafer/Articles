using StoriesManagement.Models;

namespace StoriesManagement.Services
{
    public interface IArticlesService
    {
        public Task<Article[]> GetArticles(int? categoryId = null);
        public Task<Category[]> GetCategories();
    }
}
