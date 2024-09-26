using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using VooltChallenge.Ui.Client.Models;

namespace VooltChallenge.Ui.Client.Services;

public sealed class AdService : IAdService
{
    private const string _apiBaseRoute = "api";

    private readonly HttpClient _httpClient;

    public AdService(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("WebApi");
    }

    public async Task<bool> CreateOrUpdateAsync(AdModel ad, CancellationToken token = default)
    {
        var response = await _httpClient.PostAsJsonAsync($"{_apiBaseRoute}/ads", ad, GetJsonSerializerOptions(), token);
        response.EnsureSuccessStatusCode();
        return true;
    }

    public async Task<AdsListModel> GetAllAsync(CancellationToken token = default)
    {
        return await _httpClient.GetFromJsonAsync<AdsListModel>($"{_apiBaseRoute}/ads", GetJsonSerializerOptions(), token) ?? new AdsListModel();
    }

    private JsonSerializerOptions GetJsonSerializerOptions()
    {
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };
        options.Converters.Add(new JsonStringEnumConverter());
        return options;
    }
}
