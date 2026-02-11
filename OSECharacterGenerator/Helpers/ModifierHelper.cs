namespace OSECharacterGenerator.Helpers;

/// <summary>
/// Provides ability score modifier calculations.
/// </summary>
public static class ModifierHelper
{
    /// <summary>
    /// Returns the modifier value for a given ability score.
    /// </summary>
    public static int GetModifier(int score)
    {
        return score switch
        {
            3 => -3,
            4 or 5 => -2,
            6 or 7 or 8 => -1,
            9 or 10 or 11 or 12 => 0,
            13 or 14 or 15 => 1,
            16 or 17 => 2,
            18 => 3,
            _ => 0
        };
    }
}