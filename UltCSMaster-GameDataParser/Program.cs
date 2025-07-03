namespace Taras.UltCSMaster.GameDataParser;

using System;
using System.Text.Json;

class Program
{
    static void Main(string[] args)
    {
        do
        {
            Console.WriteLine("Please enter the path to the game data file:");
            string? filePath = Console.ReadLine();

            if (filePath == null) {
                Console.WriteLine("File name cannot be null.");
                continue;
            }

            if (filePath == "") {
                Console.WriteLine("File name cannot be empty.");
                continue;
            }

            string json;
            try {
                json = File.ReadAllText(filePath);
            } catch (FileNotFoundException ex) {
                Console.WriteLine($"File not found: {ex.Message}");
                continue;
            } catch (Exception ex) {
                Console.WriteLine($"Error reading file: {ex.Message}");
                continue;
            }

            JsonDocument doc;
            try {
                doc = JsonDocument.Parse(json);
            } catch (Exception ex) {
                Console.WriteLine($"Error parsing JSON file: {ex.Message}");
                Console.WriteLine($"File content: \n{json}");
                continue;
            }

            Console.WriteLine("Parsed JSON successfully.\nContent:");
            Console.WriteLine(doc.RootElement.ToString());
            break;
        } while (true);

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}
