using System;
using System.Collections.Generic;
using System.Linq;
using OSECharacterGenerator.Classes;

namespace OSECharacterGenerator.Models;

public class Character
{
    private string _name = string.Empty;
    private int _hitPoints;

    private readonly Dictionary<Ability, int> _abilityScores = new();

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

    public CharacterClass? Class { get; set; }

    public int HitPoints
    {
        get => _hitPoints;
        set => _hitPoints = value < 1 ? 1 : value; // minimum 1
    }

    public IReadOnlyDictionary<Ability, int> AbilityScores => _abilityScores;

    public void SetAbilityScore(Ability ability, int score)
    {
        if (score < 3 || score > 18)
            throw new ArgumentOutOfRangeException(nameof(score), "Ability score must be between 3 and 18.");

        _abilityScores[ability] = score;
    }

    public int GetAbilityScore(Ability ability)
    {
        return _abilityScores[ability];
    }

    public double GetAverageAbilityScore()
    {
        if (_abilityScores.Count != 6)
            return 0;

        return _abilityScores.Values.Average();
    }
}