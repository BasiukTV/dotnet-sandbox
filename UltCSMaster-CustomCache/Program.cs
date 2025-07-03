namespace Taras.UltCSMaster.CustomCache;

public interface IDataDownloader
{
    string DownloadData(string resourceId);
}

public class CachedDataDownloader : IDataDownloader { 
    private readonly IDataDownloader _downloader;
    private readonly Dictionary<string, string> _cache = new();

    public CachedDataDownloader(IDataDownloader downloader)
    {
        _downloader = downloader;
    }

    public string DownloadData(string resourceId)
    {
        if (_cache.ContainsKey(resourceId))
        {
            Console.WriteLine($"Cache hit for {resourceId}");
            return _cache[resourceId];
        }

        Console.WriteLine($"Cache miss for {resourceId}. Downloading...");
        var data = _downloader.DownloadData(resourceId);
        _cache[resourceId] = data;
        return data;
    }
}

public class SlowDataDownloader : IDataDownloader
{
    public string DownloadData(string resourceId)
    {
        //let's imagine this method downloads real data,
        //and it does it slowly
        Thread.Sleep(1000);
        return $"Some data for {resourceId}";
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        IDataDownloader dataDownloader = new CachedDataDownloader(new SlowDataDownloader());

        Console.WriteLine(dataDownloader.DownloadData("id1"));
        Console.WriteLine(dataDownloader.DownloadData("id2"));
        Console.WriteLine(dataDownloader.DownloadData("id3"));
        Console.WriteLine(dataDownloader.DownloadData("id1"));
        Console.WriteLine(dataDownloader.DownloadData("id3"));
        Console.WriteLine(dataDownloader.DownloadData("id1"));
        Console.WriteLine(dataDownloader.DownloadData("id2"));

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}
