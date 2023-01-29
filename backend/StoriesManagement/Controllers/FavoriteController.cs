using Microsoft.AspNetCore.Mvc;
using StoriesManagement.Models;
using StoriesManagement.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StoriesManagement.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FavoriteController : ControllerBase
    {
        private IFavoriteService _favoriteService;

        public FavoriteController(IFavoriteService favoriteService)
        {
            _favoriteService = favoriteService;
        }

        [Route("GetArticles")]
        [HttpGet]
        public  ActionResult<Article[]> GetArticles()
        {
            var articles = _favoriteService.GetFavoritesArticles();

            return new OkObjectResult(articles);
        }

        [Route("Add/{id}")]
        [HttpPut]
        //public void Add(int id, [FromBody] int value)
        public async Task<ActionResult<Article[]>> Add(int id)
        {
            var articles = await _favoriteService.AddToFavorite(id);
            return new OkObjectResult(articles);
        }

        [Route("Remove/{id}")]
        [HttpDelete]
        public async Task<ActionResult<Article[]>> Remove(int id)
        {
            var articles = await _favoriteService.RemoveFromFavorite(id);
            return new OkObjectResult(articles);
        }
    }
}
