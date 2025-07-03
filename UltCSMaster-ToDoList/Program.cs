
var prompt = "Hello!\n" + "What do you want to do?\n" +
"[S]ee all TODOs\n" +
"[A]dd a TODO\n" +
"[R]emove a TODO\n" +
"[E]xit";

var todos = new List<string>();

while (true)
{
    Console.WriteLine(prompt);
    var input = Console.ReadLine()?.ToUpperInvariant();

    switch (input)
    {
        case "S":
            Console.WriteLine("Here are all your TODOs:");
            var i = 1;
            foreach (string td in todos)
            {
                Console.WriteLine($"{i} - {td}");
                i++;
            }
            break;
        case "A":
            Console.WriteLine("Please enter the TODO item:");
            var todoItem = Console.ReadLine();
            todos.Add(todoItem);
            Console.WriteLine($"TODO '{todoItem}' added.");
            break;
        case "R":
            Console.WriteLine("Please enter the TODO item to remove:");
            var todoToRemove = Console.ReadLine();
            todos.Remove(todoToRemove);
            Console.WriteLine($"TODO '{todoToRemove}' removed.");
            break;
        case "E":
            Console.WriteLine("Exiting the application. Goodbye!");
            return;
        default:
            Console.WriteLine("Invalid option, please try again.");
            break;
    }
}