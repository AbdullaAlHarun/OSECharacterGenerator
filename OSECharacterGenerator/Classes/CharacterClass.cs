using OSECharacterGenerator.Models;

namespace OSECharacterGenerator.Classes;

public abstract class CharacterClass
{
    public abstract string Name { get; }
    public abstract Ability PrimeRequisite { get; }
    public abstract int HitDieSides { get; }
    public abstract int XpForLevel2 { get; }
}