namespace UltCSMaster_StarWarsPlanetsStats.Data.Records;

using System.Text.Json.Serialization;    // JsonPropertyName / JsonNumberHandling

// 1️⃣  The item itself
public record Planet(
    [property: JsonPropertyName("uid")]
    [property: JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    int Uid,

    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("url")]  string Url
);

// 2️⃣  The outer “page” wrapper (only keep what you use)
public record PlanetPage(
    [property: JsonPropertyName("total_records")] int TotalRecords,
    [property: JsonPropertyName("total_pages")]   int TotalPages,
    [property: JsonPropertyName("previous")]      string? Previous,
    [property: JsonPropertyName("next")]          string? Next,
    [property: JsonPropertyName("results")]       List<Planet> Planets
);

