using OSECharacterGenerator.Models;

namespace OSECharacterGenerator.Classes;

/// <summary>
/// Abstract base class representing an OSE character class.
/// Defines shared properties for all concrete classes
/// such as name, prime requisite, hit die, and XP progression.
/// </summary>
public abstract class CharacterClass
{
    /// <summary>
    /// Gets the name of the character class.
    /// </summary>
    public abstract string Name { get; }

    /// <summary>
    /// Gets the prime requisite ability for the class.
    /// </summary>
    public abstract Ability PrimeRequisite { get; }

    /// <summary>
    /// Gets the number of sides on the class hit die.
    /// </summary>
    public abstract int HitDieSides { get; }

    /// <summary>
    /// Gets the experience points required to reach level 2.
    /// </summary>
    public abstract int XpForLevel2 { get; }
}