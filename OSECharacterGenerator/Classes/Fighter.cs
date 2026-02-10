using OSECharacterGenerator.Models;

namespace OSECharacterGenerator.Classes;

public sealed class Fighter : CharacterClass
{
    public override string Name => "Fighter";
    public override Ability PrimeRequisite => Ability.Strength;
    public override int HitDieSides => 8;
    public override int XpForLevel2 => 2000;
}