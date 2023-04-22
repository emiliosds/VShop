using System.Text;
using System.Text.Json;
using VShop.Web.Models;
using VShop.Web.Services.Contracts;

namespace VShop.Web.Services
{
    public class CategoryService : ICategoryService
    {
        private const string? API_ENDPOINT = "/api/products/";

        private readonly IHttpClientFactory _httpClientFactory;
        private readonly JsonSerializerOptions? _options;

        private IEnumerable<CategoryViewModel>? _list;

        public CategoryService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<IEnumerable<CategoryViewModel>> GetAllCategories()
        {
            var client = _httpClientFactory.CreateClient("ProductApi");

            IEnumerable<CategoryViewModel> categories;

            using (var response = await client.GetAsync(API_ENDPOINT))
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStreamAsync();
                    _list = await JsonSerializer.DeserializeAsync<IEnumerable<CategoryViewModel>>(apiResponse, _options);
                }
                else
                    return null;

            return _list;
        }
    }
}