public class DiceRoll
{
    public int Roll { get; }

    public DiceRoll(int sides = 6)
    {
        Roll = new Random().Next(1, sides + 1);
    }
}
