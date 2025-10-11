using VivesBlog.Model.Dto;

namespace VivesBlog.Ui.Presentation.ApiServices
{
    public class PersonApiService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public PersonApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IList<PersonDto>> Find()
        {
            var httpClient = _httpClientFactory.CreateClient("VivesBlogApi");
            var route = "/api/people";
            var response = await httpClient.GetAsync(route);
            response.EnsureSuccessStatusCode();

            var people = await response.Content.ReadFromJsonAsync<IList<PersonDto>>();
            return people ?? new List<PersonDto>();
        }

        public async Task<PersonDto?> Get(int id)
        {
            var httpClient = _httpClientFactory.CreateClient("VivesBlogApi");
            var route = $"/api/people/{id}";
            var response = await httpClient.GetAsync(route);

            if (!response.IsSuccessStatusCode)
                return null;

            return await response.Content.ReadFromJsonAsync<PersonDto>();
        }

        public async Task<PersonDto?> Create(PersonDto dto)
        {
            var httpClient = _httpClientFactory.CreateClient("VivesBlogApi");
            var route = "/api/people";
            var response = await httpClient.PostAsJsonAsync(route, dto);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<PersonDto>();
        }

        public async Task<PersonDto?> Update(int id, PersonDto dto)
        {
            var httpClient = _httpClientFactory.CreateClient("VivesBlogApi");
            var route = $"/api/people/{id}";
            var response = await httpClient.PutAsJsonAsync(route, dto);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<PersonDto>();
        }

        public async Task Delete(int id)
        {
            var httpClient = _httpClientFactory.CreateClient("VivesBlogApi");
            var route = $"/api/people/{id}";
            var response = await httpClient.DeleteAsync(route);
            response.EnsureSuccessStatusCode();
        }
    }
}