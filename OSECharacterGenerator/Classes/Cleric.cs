using OSECharacterGenerator.Models;

namespace OSECharacterGenerator.Classes;

public sealed class Cleric : CharacterClass
{
    public override string Name => "Cleric";
    public override Ability PrimeRequisite => Ability.Wisdom;
    public override int HitDieSides => 6;
    public override int XpForLevel2 => 1500;
}