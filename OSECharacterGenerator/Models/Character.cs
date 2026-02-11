using System;
using System.Collections.Generic;
using System.Linq;
using OSECharacterGenerator.Classes;

namespace OSECharacterGenerator.Models;

/// <summary>
/// Represents a generated OSE character including
/// ability scores, class, hit points, and name.
/// </summary>
public class Character
{
    private string _name = string.Empty;
    private int _hitPoints;

    private readonly Dictionary<Ability, int> _abilityScores = new();

    /// <summary>
    /// Gets or sets the character's name. Name cannot be empty.
    /// </summary>
    public string Name
    {
        get => _name;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Character name cannot be empty.");

            _name = value.Trim();
        }
    }

    /// <summary>
    /// Gets or sets the selected character class.
    /// </summary>
    public CharacterClass? Class { get; set; }

    /// <summary>
    /// Gets or sets the character's hit points. Minimum value is 1.
    /// </summary>
    public int HitPoints
    {
        get => _hitPoints;
        set => _hitPoints = value < 1 ? 1 : value;
    }

    /// <summary>
    /// Gets a read-only view of the character's ability scores.
    /// </summary>
    public IReadOnlyDictionary<Ability, int> AbilityScores => _abilityScores;

    /// <summary>
    /// Sets the score for a specific ability (must be 3–18).
    /// </summary>
    /// <param name="ability">The ability to set.</param>
    /// <param name="score">The score value (3–18).</param>
    public void SetAbilityScore(Ability ability, int score)
    {
        if (score < 3 || score > 18)
            throw new ArgumentOutOfRangeException(nameof(score), "Ability score must be between 3 and 18.");

        _abilityScores[ability] = score;
    }

    /// <summary>
    /// Gets the score for a specific ability.
    /// </summary>
    /// <param name="ability">The ability to read.</param>
    /// <returns>The ability score.</returns>
    public int GetAbilityScore(Ability ability)
    {
        return _abilityScores[ability];
    }

    /// <summary>
    /// Calculates the average of all six ability scores.
    /// Returns 0 if all six have not been set yet.
    /// </summary>
    /// <returns>The average ability score.</returns>
    public double GetAverageAbilityScore()
    {
        if (_abilityScores.Count != 6)
            return 0;

        return _abilityScores.Values.Average();
    }
}
