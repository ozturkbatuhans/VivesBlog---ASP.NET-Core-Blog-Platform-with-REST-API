using System.Net.Http.Json;
using VivesBlog.Model.Dto;
using static VivesBlog.Model.Dto.ArticleDto;

namespace VivesBlog.Sdk
{
    public class VivesBlogApiClient
    {
        private readonly HttpClient _httpClient;

        public VivesBlogApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // People
        public async Task<IList<PersonDto>> GetPeople()
        {
            var people = await _httpClient.GetFromJsonAsync<IList<PersonDto>>("/api/people");
            return people ?? new List<PersonDto>();
        }

        public async Task<PersonDto?> GetPerson(int id)
        {
            return await _httpClient.GetFromJsonAsync<PersonDto>($"/api/people/{id}");
        }

        public async Task<PersonDto?> CreatePerson(PersonDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/people", dto);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<PersonDto>();
        }

        public async Task<PersonDto?> UpdatePerson(int id, PersonDto dto)
        {
            var response = await _httpClient.PutAsJsonAsync($"/api/people/{id}", dto);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<PersonDto>();
        }

        public async Task DeletePerson(int id)
        {
            var response = await _httpClient.DeleteAsync($"/api/people/{id}");
            response.EnsureSuccessStatusCode();
        }

        // Articles
        public async Task<IList<ArticleDto>> GetArticles()
        {
            var articles = await _httpClient.GetFromJsonAsync<IList<ArticleDto>>("/api/articles");
            return articles ?? new List<ArticleDto>();
        }

        public async Task<ArticleDto?> GetArticle(int id)
        {
            return await _httpClient.GetFromJsonAsync<ArticleDto>($"/api/articles/{id}");
        }

        public async Task<ArticleDto?> CreateArticle(ArticleCreateDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/articles", dto);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<ArticleDto>();
        }

        public async Task<ArticleDto?> UpdateArticle(int id, ArticleUpdateDto dto)
        {
            var response = await _httpClient.PutAsJsonAsync($"/api/articles/{id}", dto);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<ArticleDto>();
        }

        public async Task DeleteArticle(int id)
        {
            var response = await _httpClient.DeleteAsync($"/api/articles/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}