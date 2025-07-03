namespace UltCSMaster_StarWarsPlanetsStats.Data.Providers;

public interface IProvider<T> where T : class {
    Task<IEnumerable<T>> GetDataAsync();
}
