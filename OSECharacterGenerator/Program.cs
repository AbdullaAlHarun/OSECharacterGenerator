using System;
using System.Collections.Generic;
using System.Linq;
using OSECharacterGenerator.Classes;
using OSECharacterGenerator.Helpers;
using OSECharacterGenerator.Models;

namespace OSECharacterGenerator;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== OSE Character Generator ===");

        var character = new Character();

        // 1) Roll ability scores + reroll rule
        RollAbilityScoresWithRerollRule(character);

        // 2) Name
        Console.Write("Enter character name: ");
        character.Name = ReadNonEmptyLine();

        // 3) Class selection (eligibility rule)
        var availableClasses = GetEligibleClasses(character);
        var chosenClass = ChooseClass(character, availableClasses);
        character.Class = chosenClass;

        // 4) Modifiers needed (Prime + CON for HP)
        int conScore = character.GetAbilityScore(Ability.Constitution);
        int conMod = ModifierHelper.GetModifier(conScore);

        // 5) HP
        int hpRoll = DiceRoller.RollDie(chosenClass.HitDieSides);
        character.HitPoints = hpRoll + conMod; // Character enforces minimum 1

        // 6) Display
        DisplayCharacter(character, hpRoll, conMod);

        Console.WriteLine("\nPress Enter to exit...");
        Console.ReadLine();
    }

    private static void RollAbilityScoresWithRerollRule(Character character)
    {
        while (true)
        {
            RollAllSixScores(character);

            double avg = character.GetAverageAbilityScore();
            Console.WriteLine($"Average score: {avg:F1}");

            if (avg > 8)
                return;

            Console.Write("Your ability scores are below average. Would you like to reroll? (Y/N): ");
            string answer = ReadYesNo();
            if (answer == "N")
                return;

            Console.WriteLine("Rerolling...\n");
        }
    }

    private static void RollAllSixScores(Character character)
    {
        Console.WriteLine("Rolling ability scores...");

        // Must be rolled in this order (assignment requirement)
        var order = new[]
        {
            Ability.Strength,
            Ability.Intelligence,
            Ability.Wisdom,
            Ability.Dexterity,
            Ability.Constitution,
            Ability.Charisma
        };

        foreach (var ability in order)
        {
            int score = DiceRoller.Roll3d6();
            character.SetAbilityScore(ability, score);
            Console.WriteLine($" {AbilityShort(ability)}: {score}");
        }
    }

    private static List<CharacterClass> GetEligibleClasses(Character character)
    {
        // Find the top two ability VALUES (ties allowed)
        var topTwoValues = character.AbilityScores.Values
            .OrderByDescending(v => v)
            .Distinct()
            .Take(2)
            .ToHashSet();

        var all = new List<CharacterClass>
        {
            new Cleric(),
            new Fighter(),
            new MagicUser(),
            new Thief()
        };

        return all
            .Where(c => topTwoValues.Contains(character.GetAbilityScore(c.PrimeRequisite)))
            .ToList();
    }

    private static CharacterClass ChooseClass(Character character, List<CharacterClass> available)
    {
        if (available.Count == 1)
        {
            Console.WriteLine($"Only one class available: {available[0].Name}\n");
            return available[0];
        }

        Console.WriteLine("\nAvailable classes based on your scores:");
        for (int i = 0; i < available.Count; i++)
        {
            var c = available[i];
            int primeScore = character.GetAbilityScore(c.PrimeRequisite);
            Console.WriteLine($" {i + 1}. {c.Name} (Prime: {c.PrimeRequisite} {primeScore})");
        }

        Console.Write($"Select a class (1-{available.Count}): ");
        int choice = ReadIntInRange(1, available.Count);
        Console.WriteLine();
        return available[choice - 1];
    }

    private static void DisplayCharacter(Character character, int hpRoll, int conMod)
    {
        var cls = character.Class!;
        int primeScore = character.GetAbilityScore(cls.PrimeRequisite);
        int primeMod = ModifierHelper.GetModifier(primeScore);

        Console.WriteLine("=== Character Created ===");
        Console.WriteLine($"Name: {character.Name}");
        Console.WriteLine($"Class: {cls.Name}");
        string conPart = conMod >= 0 ? $"+ {conMod}" : $"- {Math.Abs(conMod)}";
        Console.WriteLine($"Hit Points: {character.HitPoints} (1d{cls.HitDieSides} {conPart})");

        Console.WriteLine("Ability Scores:");
        Console.WriteLine(
            $" STR: {character.GetAbilityScore(Ability.Strength)}  " +
            $"INT: {character.GetAbilityScore(Ability.Intelligence)}  " +
            $"WIS: {character.GetAbilityScore(Ability.Wisdom)}");
        Console.WriteLine(
            $" DEX: {character.GetAbilityScore(Ability.Dexterity)}  " +
            $"CON: {character.GetAbilityScore(Ability.Constitution)}  " +
            $"CHA: {character.GetAbilityScore(Ability.Charisma)}");

        Console.WriteLine($"Prime Requisite: {cls.PrimeRequisite} ({primeScore}) - Modifier: {FormatMod(primeMod)}");
        Console.WriteLine($"XP for Level 2: {cls.XpForLevel2:N0}");
    }

    private static string ReadNonEmptyLine()
    {
        while (true)
        {
            string? input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
                return input.Trim();

            Console.Write("Please enter a value: ");
        }
    }

    private static string ReadYesNo()
    {
        while (true)
        {
            string input = (Console.ReadLine() ?? "").Trim().ToUpperInvariant();
            if (input is "Y" or "N")
                return input;

            Console.Write("Please type Y or N: ");
        }
    }

    private static int ReadIntInRange(int min, int max)
    {
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out int val) && val >= min && val <= max)
                return val;

            Console.Write($"Invalid selection. Enter a number {min}-{max}: ");
        }
    }

    private static string FormatMod(int mod) => mod >= 0 ? $"+{mod}" : mod.ToString();

    private static string AbilityShort(Ability ability) => ability switch
    {
        Ability.Strength => "Strength",
        Ability.Intelligence => "Intelligence",
        Ability.Wisdom => "Wisdom",
        Ability.Dexterity => "Dexterity",
        Ability.Constitution => "Constitution",
        Ability.Charisma => "Charisma",
        _ => ability.ToString()
    };
}
