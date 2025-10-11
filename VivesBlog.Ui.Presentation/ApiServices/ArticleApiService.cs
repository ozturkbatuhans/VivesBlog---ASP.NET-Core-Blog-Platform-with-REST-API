using VivesBlog.Model.Dto;
using static VivesBlog.Model.Dto.ArticleDto;

namespace VivesBlog.Ui.Presentation.ApiServices
{
    public class ArticleApiService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ArticleApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IList<ArticleDto>> Find()
        {
            var httpClient = _httpClientFactory.CreateClient("VivesBlogApi");
            var route = "/api/articles";
            var response = await httpClient.GetAsync(route);
            response.EnsureSuccessStatusCode();

            var articles = await response.Content.ReadFromJsonAsync<IList<ArticleDto>>();
            return articles ?? new List<ArticleDto>();
        }

        public async Task<ArticleDto?> Get(int id)
        {
            var httpClient = _httpClientFactory.CreateClient("VivesBlogApi");
            var route = $"/api/articles/{id}";
            var response = await httpClient.GetAsync(route);

            if (!response.IsSuccessStatusCode)
                return null;

            return await response.Content.ReadFromJsonAsync<ArticleDto>();
        }

        public async Task<ArticleDto?> Create(ArticleCreateDto dto)
        {
            var httpClient = _httpClientFactory.CreateClient("VivesBlogApi");
            var route = "/api/articles";
            var response = await httpClient.PostAsJsonAsync(route, dto);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<ArticleDto>();
        }

        public async Task<ArticleDto?> Update(int id, ArticleUpdateDto dto)
        {
            var httpClient = _httpClientFactory.CreateClient("VivesBlogApi");
            var route = $"/api/articles/{id}";
            var response = await httpClient.PutAsJsonAsync(route, dto);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<ArticleDto>();
        }

        public async Task Delete(int id)
        {
            var httpClient = _httpClientFactory.CreateClient("VivesBlogApi");
            var route = $"/api/articles/{id}";
            var response = await httpClient.DeleteAsync(route);
            response.EnsureSuccessStatusCode();
        }
    }
}