namespace OSECharacterGenerator.Helpers;

public static class DiceRoller
{
    private static readonly Random Rng = new();

    public static int RollDie(int sides)
    {
        if (sides < 2)
            throw new ArgumentOutOfRangeException(nameof(sides));

        return Rng.Next(1, sides + 1);
    }

    public static int Roll3d6()
    {
        return RollDie(6) + RollDie(6) + RollDie(6);
    }
}