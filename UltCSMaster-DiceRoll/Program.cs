// See https://aka.ms/new-console-template for more information
Console.WriteLine("You have three tries to guess the dice roll!");

DiceRoll diceRoll = new DiceRoll();

for (int i = 0; i < 3; i++)
{
    Console.WriteLine($"Try {i + 1}: Enter your guess (1-6)!");
    bool validGuess = false;
    int guess = 0;
    do
    {
        string input = Console.ReadLine();
        validGuess = int.TryParse(input, out guess) && guess >= 1 && guess <= 6;
        if (!validGuess)
        {
            Console.WriteLine("Invalid input! Please enter a number between 1 and 6.");
        }
    } while (!validGuess);

    if (diceRoll.Roll == guess) {
        Console.WriteLine("Congratulations! You guessed the dice roll correctly!");
        return;
    } else {
        Console.WriteLine("Wrong guess! Try again.");
    }
}

Console.WriteLine("No more tries left! You lose!");
