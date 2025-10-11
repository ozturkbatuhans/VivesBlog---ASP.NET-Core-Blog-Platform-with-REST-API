using Microsoft.AspNetCore.Mvc;
using VivesBlog.Model.Dto;
using VivesBlog.Sdk;
using static VivesBlog.Model.Dto.ArticleDto;

namespace VivesBlog.Ui.Presentation.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly VivesBlogApiClient _apiClient;

        public ArticlesController(VivesBlogApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<IActionResult> Index()
        {
            var articles = await _apiClient.GetArticles();
            return View(articles);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var authors = await _apiClient.GetPeople();
            ViewBag.Authors = authors;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ArticleCreateDto dto)
        {
            if (!ModelState.IsValid)
            {
                var authors = await _apiClient.GetPeople();
                ViewBag.Authors = authors;
                return View(dto);
            }

            await _apiClient.CreateArticle(dto);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit([FromRoute] int id)
        {
            var article = await _apiClient.GetArticle(id);
            if (article is null)
            {
                return RedirectToAction("Index");
            }

            var authors = await _apiClient.GetPeople();
            ViewBag.Authors = authors;

            var updateDto = new ArticleUpdateDto
            {
                Title = article.Title,
                Content = article.Content,
                AuthorId = article.AuthorId
            };

            return View(updateDto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromForm] ArticleUpdateDto dto)
        {
            if (!ModelState.IsValid)
            {
                var authors = await _apiClient.GetPeople();
                ViewBag.Authors = authors;
                return View(dto);
            }

            await _apiClient.UpdateArticle(id, dto);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("[controller]/Delete")]
        public async Task<IActionResult> DeleteConfirmed([FromForm] int id)
        {
            await _apiClient.DeleteArticle(id);
            return RedirectToAction("Index");
        }
    }
}