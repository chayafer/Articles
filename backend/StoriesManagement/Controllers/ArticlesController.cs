using Microsoft.AspNetCore.Mvc;
using StoriesManagement.Models;
using StoriesManagement.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StoriesManagement.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private IArticlesService _articleService;

        public ArticlesController(IArticlesService articleService)
        {
            _articleService = articleService;
        }

        [Route("GetArticles")]
        [HttpGet]
        public async Task<ActionResult<ArticleBase[]>> GetArticles()
        {
            var articles = await _articleService.GetArticles();

            return new OkObjectResult(articles);
        }

        [Route("GetArticles/{categoryId}")]
        [HttpGet]
        public async Task<ActionResult<Article[]>> GetArticlesByCatId([FromRoute] int categoryId)
        {
            var articles = await _articleService.GetArticles(categoryId);

            return new OkObjectResult(articles);
        }

        [Route("GetCategories")]
        [HttpGet]
        public async Task<ActionResult<Category[]>> GetCategories()
        {
            var articles = await _articleService.GetCategories();

            return new OkObjectResult(articles);
        }
    }
}
