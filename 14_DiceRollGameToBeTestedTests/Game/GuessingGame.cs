namespace _14_DiceRollGameToBeTestedTests;

using Game;
using NUnit.Framework;
using Moq;
using UserCommunication;

[TestFixture]
public class GuessingGameTests
{
    private Mock<IDice> _diceMock;
    private Mock<IUserCommunication> _userCommunicationMock;
    private GuessingGame _guessingGame;

    [SetUp]
    public void SetUp()
    {
        // This method is called before each test.
        // You can use it to set up common test data or mock objects.
        _diceMock = new Mock<IDice>();
        _userCommunicationMock = new Mock<IUserCommunication>();
        _guessingGame = new GuessingGame(_diceMock.Object, _userCommunicationMock.Object);
    }


    [Test]
    public void NullDice_ThrowsNullReferenceException()
    {
        // TODO: This is bad design. We should not allow null IDice to be passed.
        // This test is here to demonstrate the issue and should be fixed in the future.
        _guessingGame = new GuessingGame(null!, _userCommunicationMock.Object);

        Assert.Throws<NullReferenceException>(() => _guessingGame.Play());
    }

    [Test]
    public void NullUserCommunication_ThrowsNullReferenceException()
    {
        // TODO: This is bad design. We should not allow null IUserCommunication to be passed.
        // This test is here to demonstrate the issue and should be fixed in the future.
        _guessingGame = new GuessingGame(_diceMock.Object, null!);

        Assert.Throws<NullReferenceException>(() => _guessingGame.Play());
    }

    [Test]
    public void Play_WhenUserGuessesCorrectlyOnFirstTry_ReturnsVictory()
    {
        // Arrange
        int expectedDiceRoll = 4;
        _diceMock.Setup(d => d.Roll()).Returns(expectedDiceRoll);
        _userCommunicationMock.Setup(uc => uc.ReadInteger(It.IsAny<string>())).Returns(expectedDiceRoll);

        // Act
        var result = _guessingGame.Play();

        // Assert
        Assert.That(result, Is.EqualTo(GameResult.Victory));
    }

    [Test]
    public void Play_WhenUserGuessesIncorrectly_ReturnsLossAfterAllTries()
    {
        // Arrange
        int expectedDiceRoll = 5; // The number the dice will roll every time
        _diceMock.Setup(d => d.Roll()).Returns(expectedDiceRoll);
        _userCommunicationMock.SetupSequence(uc => uc.ReadInteger(It.IsAny<string>()))
            .Returns(1) // First guess
            .Returns(2) // Second guess
            .Returns(3); // Third guess

        // Act
        var result = _guessingGame.Play();

        // Assert
        Assert.That(result, Is.EqualTo(GameResult.Loss));
    }

    [Test]
    public void Play_WhenUserGuessesCorrectlyOnSecondTry_ReturnsVictory()
    {
        // Arrange
        int expectedDiceRoll = 6;
        _diceMock.Setup(d => d.Roll()).Returns(expectedDiceRoll);
        _userCommunicationMock.SetupSequence(uc => uc.ReadInteger(It.IsAny<string>()))
            .Returns(1) // First wrong guess
            .Returns(expectedDiceRoll); // Second guess

        // Act
        var result = _guessingGame.Play();

        // Assert
        Assert.That(result, Is.EqualTo(GameResult.Victory));
    }

    [Test]
    public void Play_WhenUserGuessesCorrectlyOnThirdTry_ReturnsVictory()
    {
        // Arrange
        int expectedDiceRoll = 6;
        _diceMock.Setup(d => d.Roll()).Returns(expectedDiceRoll);
        _userCommunicationMock.SetupSequence(uc => uc.ReadInteger(It.IsAny<string>()))
            .Returns(1) // First wrong guess
            .Returns(2) // Second wrong guess
            .Returns(expectedDiceRoll); // Third guess

        // Act
        var result = _guessingGame.Play();

        // Assert
        Assert.That(result, Is.EqualTo(GameResult.Victory));
    }

    [Test]
    public void PrintResult_WhenGameResultIsVictory_ShowsWinMessage()
    {
        // Arrange
        var gameResult = GameResult.Victory;
        _userCommunicationMock.Setup(uc => uc.ShowMessage(It.IsAny<string>()));

        // Act
        _guessingGame.PrintResult(gameResult);

        // Assert
        _userCommunicationMock.Verify(uc => uc.ShowMessage("You win!"), Times.Once);
    }

    [Test]
    public void PrintResult_WhenGameResultIsLoss_ShowsLossMessage()
    {
        // Arrange
        var gameResult = GameResult.Loss;
        _userCommunicationMock.Setup(uc => uc.ShowMessage(It.IsAny<string>()));

        // Act
        _guessingGame.PrintResult(gameResult);

        // Assert
        _userCommunicationMock.Verify(uc => uc.ShowMessage("You lose :("), Times.Once);
    }
}
