using System.Text.Json;
using VShop.Web.Models;

namespace VShop.Web.Services;

public abstract class ServiceBase<TViewModel> : IServiceBase<TViewModel> where TViewModel : ViewModelBase
{
    internal readonly HttpClient _client;
    internal readonly string? _endPoint;
    internal readonly JsonSerializerOptions? _options;

    internal TViewModel? _object;
    internal IEnumerable<TViewModel>? _list;

    protected ServiceBase(IHttpClientFactory httpClientFactory, string endPoint)
    {
        _endPoint = endPoint;
        _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        _client = httpClientFactory.CreateClient("ProductApi");
    }

    public async Task<TViewModel?> Create(TViewModel model)
    {
        using (var response = await _client.PostAsJsonAsync(_endPoint, model))
            if (response.IsSuccessStatusCode)
            {
                var apiResponse = await response.Content.ReadAsStreamAsync();
                _object = await JsonSerializer.DeserializeAsync<TViewModel>(apiResponse, _options);
            }
            else
                return null;

        return _object;
    }

    public async Task<TViewModel?> Update(TViewModel model)
    {
        using (var response = await _client.PutAsJsonAsync(_endPoint, model))
            if (response.IsSuccessStatusCode)
            {
                var apiResponse = await response.Content.ReadAsStreamAsync();
                _object = await JsonSerializer.DeserializeAsync<TViewModel>(apiResponse, _options);
            }
            else
                return null;

        return _object;
    }

    public async Task<bool> Delete(Guid id)
    {
        using var response = await _client.DeleteAsync(_endPoint + id);
        if (response.IsSuccessStatusCode)
            return true;

        return false;
    }

    public async Task<TViewModel?> GetById(Guid id)
    {
        using (var response = await _client.GetAsync(_endPoint + id))
            if (response.IsSuccessStatusCode)
            {
                var apiResponse = await response.Content.ReadAsStreamAsync();
                _object = await JsonSerializer.DeserializeAsync<TViewModel>(apiResponse, _options);
            }
            else
                return null;

        return _object;
    }

    public async Task<IEnumerable<TViewModel?>?> GetAll()
    {
        using (var response = await _client.GetAsync(_endPoint))
            if (response.IsSuccessStatusCode)
            {
                var apiResponse = await response.Content.ReadAsStreamAsync();
                _list = await JsonSerializer.DeserializeAsync<IEnumerable<TViewModel>?>(apiResponse, _options);
            }
            else
                return null;

        return _list;
    }
}