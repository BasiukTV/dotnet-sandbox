using FibonacciGenerator;

using NUnit.Framework;

namespace FibonacciGeneratorTests;

[TestFixture]
public class FibonacciTests
{
    [Test]
    public void Generate_NegativeInput_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => Fibonacci.Generate(-1));
    }

    [Test]
    public void Generate_LargeInput_ThrowsArgumentException()
    {
        const int MaxValidNumber = 46;
        Assert.Throws<ArgumentException>(() => Fibonacci.Generate(MaxValidNumber + 1));
    }

    [TestCase(0, new[] { 0 })]
    [TestCase(1, new[] { 0, 1 })]
    [TestCase(2, new[] { 0, 1, 1 })]
    [TestCase(3, new[] { 0, 1, 1, 2 })]
    [TestCase(4, new[] { 0, 1, 1, 2, 3 })]
    [TestCase(5, new[] { 0, 1, 1, 2, 3, 5 })]
    [TestCase(6, new[] { 0, 1, 1, 2, 3, 5, 8 })]
    [TestCase(7, new[] { 0, 1, 1, 2, 3, 5, 8, 13 })]
    [TestCase(8, new[] { 0, 1, 1, 2, 3, 5, 8, 13, 21 })]
    [TestCase(9, new[] { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34 })]
    [TestCase(10, new[] { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55 })]
    public void Generate_ValidInput_ReturnsExpectedSequence(int input, int[] expected)
    {
        var result = Fibonacci.Generate(input);
        Assert.AreEqual(expected, result);
    }
}