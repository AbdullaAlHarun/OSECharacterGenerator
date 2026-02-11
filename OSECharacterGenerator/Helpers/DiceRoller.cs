using System;

namespace OSECharacterGenerator.Helpers;

/// <summary>
/// Provides utility methods for rolling dice.
/// </summary>
public static class DiceRoller
{
    private static readonly Random Rng = new();

    /// <summary>
    /// Rolls a single die with the specified number of sides.
    /// </summary>
    public static int RollDie(int sides)
    {
        if (sides < 2)
            throw new ArgumentOutOfRangeException(nameof(sides));

        return Rng.Next(1, sides + 1);
    }

    /// <summary>
    /// Rolls three six-sided dice and returns the total.
    /// </summary>
    public static int Roll3d6()
    {
        return RollDie(6) + RollDie(6) + RollDie(6);
    }
}