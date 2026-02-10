using OSECharacterGenerator.Models;

namespace OSECharacterGenerator.Classes;

public sealed class MagicUser : CharacterClass
{
    public override string Name => "Magic-User";
    public override Ability PrimeRequisite => Ability.Intelligence;
    public override int HitDieSides => 4;
    public override int XpForLevel2 => 2500;
}