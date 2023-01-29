using StoriesManagement.Models;

namespace StoriesManagement.Services
{
    public interface IFavoriteService
    {
        Task<ArticleBase[]> AddToFavorite(int id);

        Task<ArticleBase[]> RemoveFromFavorite(int id);

        Article[] GetFavoritesArticles();


    }
}
