using Microsoft.Identity.Client;
using StoriesManagement.Models;
using System.Data.Common;

namespace StoriesManagement.Services
{
    public class FavoriteService : IFavoriteService
    {
        private DBContext _dbContext;

        public FavoriteService(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ArticleBase[]> AddToFavorite(int id)
        {
            if (_dbContext.Favorites.FirstOrDefault(a => a.ArticleId == id) == null)
            {
                _dbContext.Favorites.Add(new Favorite { ArticleId = id });
                _dbContext.SaveChanges();
            }
            return GetFavoritesArticles();
        }


        public async Task<ArticleBase[]> RemoveFromFavorite(int id)
        {
            var favorite = _dbContext.Favorites.FirstOrDefault(a => a.ArticleId == id);
            if(favorite != null)
            {
                 _dbContext.Favorites.Remove(favorite);
                _dbContext.SaveChanges();
            }
           
            _dbContext.SaveChanges();
            return GetFavoritesArticles();
        }

        public Article[] GetFavoritesArticles()
        {
            return _dbContext.Articles.Join(_dbContext.Favorites,
            article => article.Id,
            favorite => favorite.ArticleId,
            (article, favoriteta) => new Article
            {
                CategoryId = article.CategoryId,
                Description = article.Description,
                Id = article.Id,
                Image = article.Image,
                Title = article.Title,
                IsFavorite = true
            }).ToArray();

        }





    }
}
