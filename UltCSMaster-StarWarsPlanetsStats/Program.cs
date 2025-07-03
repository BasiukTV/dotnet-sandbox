using UltCSMaster_StarWarsPlanetsStats.Data.Providers;
using UltCSMaster_StarWarsPlanetsStats.Data.Records;

List<Planet> planets = new PlanetsProvider().GetDataAsync().GetAwaiter().GetResult()?.Planets
    ?? new List<Planet>();

foreach (var planet in planets)
{
    Console.WriteLine(planet);
}
