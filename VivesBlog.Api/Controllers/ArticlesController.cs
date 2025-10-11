using Microsoft.AspNetCore.Mvc;
using VivesBlog.Model;
using VivesBlog.Model.Dto;
using VivesBlog.Services;
using static VivesBlog.Model.Dto.ArticleDto;

namespace VivesBlog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly ArticleService _articleService;

        public ArticlesController(ArticleService articleService)
        {
            _articleService = articleService;
        }

        [HttpGet]
        public IActionResult Find()
        {
            var articles = _articleService.Find();

            var dtos = articles.Select(a => new ArticleDto
            {
                Id = a.Id,
                Title = a.Title,
                Content = a.Content,
                CreatedDate = a.CreatedDate,
                AuthorId = a.AuthorId,
                AuthorName = a.Author != null
                    ? $"{a.Author.FirstName} {a.Author.LastName}"
                    : "Unknown"
            }).ToList();

            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var article = _articleService.Get(id);
            if (article == null)
                return NotFound();

            var dto = new ArticleDto
            {
                Id = article.Id,
                Title = article.Title,
                Content = article.Content,
                CreatedDate = article.CreatedDate,
                AuthorId = article.AuthorId,
                AuthorName = article.Author != null
                    ? $"{article.Author.FirstName} {article.Author.LastName}"
                    : "Unknown"
            };

            return Ok(dto);
        }

        [HttpPost]
        public IActionResult Create([FromBody] ArticleCreateDto dto)
        {
            var article = new Article
            {
                Title = dto.Title,
                Content = dto.Content,
                AuthorId = dto.AuthorId
            };

            var created = _articleService.Create(article);

            var resultDto = new ArticleDto
            {
                Id = created.Id,
                Title = created.Title,
                Content = created.Content,
                CreatedDate = created.CreatedDate,
                AuthorId = created.AuthorId,
                AuthorName = created.Author != null
                    ? $"{created.Author.FirstName} {created.Author.LastName}"
                    : "Unknown"
            };

            return CreatedAtAction(nameof(Get), new { id = resultDto.Id }, resultDto);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] ArticleUpdateDto dto)
        {
            var article = new Article
            {
                Title = dto.Title,
                Content = dto.Content,
                AuthorId = dto.AuthorId
            };

            var updated = _articleService.Update(id, article);
            if (updated == null)
                return NotFound();

            var resultDto = new ArticleDto
            {
                Id = updated.Id,
                Title = updated.Title,
                Content = updated.Content,
                CreatedDate = updated.CreatedDate,
                AuthorId = updated.AuthorId,
                AuthorName = updated.Author != null
                    ? $"{updated.Author.FirstName} {updated.Author.LastName}"
                    : "Unknown"
            };

            return Ok(resultDto);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _articleService.Delete(id);
            return NoContent();
        }
    }
}