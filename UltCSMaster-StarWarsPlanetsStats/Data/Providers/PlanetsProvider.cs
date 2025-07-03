using UltCSMaster_StarWarsPlanetsStats.Data.Records;
using System.Net.Http.Json;

namespace UltCSMaster_StarWarsPlanetsStats.Data.Providers;

public class PlanetsProvider  {

    private const string API_ENDPOINT = "https://www.swapi.tech/api/";
    private const string PLANETS_API_PATH = "planets/";
    private readonly HttpClient _httpClient = new HttpClient {
        BaseAddress = new Uri(API_ENDPOINT + PLANETS_API_PATH)
    };

    public async Task<PlanetPage?> GetDataAsync() {
        var response = await _httpClient.GetAsync(string.Empty);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<PlanetPage>();
    }
}