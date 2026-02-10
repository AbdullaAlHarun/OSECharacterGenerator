using OSECharacterGenerator.Models;

namespace OSECharacterGenerator.Classes;

public sealed class Thief : CharacterClass
{
    public override string Name => "Thief";
    public override Ability PrimeRequisite => Ability.Dexterity;
    public override int HitDieSides => 4;
    public override int XpForLevel2 => 1200;
}