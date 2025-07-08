namespace _14_DiceRollGameToBeTestedTests;

using Game;
using NUnit.Framework;

[TestFixture]
public class DiceTests
{

    [Test]
    public void Roll_ReturnsExpectedValue()
    {

        // Set up a fixed random seed to ensure the same result every time
        Dice dice = new Dice(new Random(123456));

        // Roll the dice until we get all expected values
        Assert.That(dice.Roll(), Is.EqualTo(2));
        Assert.That(dice.Roll(), Is.EqualTo(1));
        Assert.That(dice.Roll(), Is.EqualTo(1));
        Assert.That(dice.Roll(), Is.EqualTo(3));
        Assert.That(dice.Roll(), Is.EqualTo(5));
        Assert.That(dice.Roll(), Is.EqualTo(3));
        Assert.That(dice.Roll(), Is.EqualTo(2));
        Assert.That(dice.Roll(), Is.EqualTo(3));
        Assert.That(dice.Roll(), Is.EqualTo(4));
        Assert.That(dice.Roll(), Is.EqualTo(5));
        Assert.That(dice.Roll(), Is.EqualTo(1));
        Assert.That(dice.Roll(), Is.EqualTo(3));
        Assert.That(dice.Roll(), Is.EqualTo(4));
        Assert.That(dice.Roll(), Is.EqualTo(1));
        Assert.That(dice.Roll(), Is.EqualTo(5));
        Assert.That(dice.Roll(), Is.EqualTo(6));
    }

    [Test]
    public void DiceWithNullRandom_ThrowsNullReferenceException()
    {
        // TODO: This is bad design. We should not allow null Random to be passed.
        // This test is here to demonstrate the issue and should be fixed in the future.
        var dice = new Dice(null!);

        Assert.Throws<NullReferenceException>(() => dice.Roll());
    }
}