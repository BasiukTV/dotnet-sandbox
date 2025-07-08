// This project code copied from the below link to practice unit testing:
// https://github.com/KrystynaSlusarczykLearning/UltimateCSharpMasterclass/tree/main/14_DiceRollGameToBeTested

using Game;
using UserCommunication;

var random = new Random();
var dice = new Dice(random);
var userCommunication = new ConsoleUserCommunication();
var guessingGame = new GuessingGame(dice, userCommunication);

GameResult gameResult = guessingGame.Play();
guessingGame.PrintResult(gameResult);

Console.ReadKey();
