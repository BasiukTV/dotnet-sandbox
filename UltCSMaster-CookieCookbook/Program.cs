

namespace Taras.UltCSMaster.CookieCookbook;

class Ingredient
{
    public int Id { get; }
    public string Name { get; }
    public string PrepInstructions { get; }

    public Ingredient(int id, string name, string prepInstructions)
    {
        Id = id;
        Name = name;
        PrepInstructions = prepInstructions;
    }
}

public class Cookbook
{

    private static List<Ingredient> Ingredients { get; } = new List<Ingredient> {
        new Ingredient (1, "Wheat flour", "Sieve. Add to other ingredients."),
        new Ingredient (2, "Coconut flour", "Sieve. Add to other ingredients."),
        new Ingredient (3, "Butter", "Melt on low heat. Add to other ingredients."),
        new Ingredient (4, "Chocolate", "Melt in a water bath. Add to other ingredients."),
        new Ingredient (5, "Sugar", "Add to other ingredients."),
        new Ingredient (6, "Cardamom", "Take half a teaspoon. Add to other ingredients."),
        new Ingredient (7, "Cinnamon", "Take half a teaspoon. Add to other ingredients."),
        new Ingredient (8, "Cocoa powder", "Add to other ingredients.")
    };

    private List<List<int>> Recipes { get; }

    public Cookbook(List<List<int>> recipes)
    {
        Recipes = recipes;
    }
}

public enum FileFormat
{
    JSON,
    CSV
}

public static class CookbookFileManager
{
    public static string Save(Cookbook cookbook, FileFormat format)
    {
        switch (format)
        {
            case FileFormat.JSON:
                return SaveToJson(cookbook);
            case FileFormat.CSV:
                return SaveToCsv(cookbook);
            default:
                throw new ArgumentOutOfRangeException(nameof(format), format, null);
        }
    }

    private static string SaveToJson(Cookbook cookbook)
    {
        // Implement JSON serialization logic here
        return "Serialized to JSON";
    }

    private static string SaveToCsv(Cookbook cookbook)
    {
        // Implement CSV serialization logic here
        return "Serialized to CSV";
    }

    public static Cookbook Load(string filePath, FileFormat format)
    {
        switch (format)
        {
            case FileFormat.JSON:
                return LoadFromJson(filePath);
            case FileFormat.CSV:
                return LoadFromCsv(filePath);
            default:
                throw new ArgumentOutOfRangeException(nameof(format), format, null);
        }
    }

    private static Cookbook LoadFromJson(string filePath)
    {
        // Implement JSON deserialization logic here
        return new Cookbook(new List<List<int>>());
    }

    private static Cookbook LoadFromCsv(string filePath)
    {
        // Implement CSV deserialization logic here
        return new Cookbook(new List<List<int>>());
    }
}

class Program
{
    // Default file format can be set here
    private static readonly FileFormat fileFormat = FileFormat.CSV;
    // private static readonly FileFormat fileFormat = FileFormat.CSV;

    static void Main(string[] args)
    {
        // Example usage of the file format enum
        switch (fileFormat)
        {
            case FileFormat.JSON:
                Console.WriteLine("Using JSON format.");
                break;
            case FileFormat.CSV:
                Console.WriteLine("Using CSV format.");
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}
