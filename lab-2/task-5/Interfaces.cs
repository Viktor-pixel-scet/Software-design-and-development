using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;

namespace Interfaces
{
    public interface ICharacterBuilder
    {
        ICharacterBuilder SetHeight(int height);
        ICharacterBuilder SetPhysique(string physique);
        ICharacterBuilder SetHairColor(string hairColor);
        ICharacterBuilder SetEyeColor(string eyeColor);
        ICharacterBuilder SetClothing(string clothing);
        ICharacterBuilder AddInventoryItem(string item);
        ICharacterBuilder AddDeed(string deed);
        ICharacterBuilder SetBaseStats(int strength, int agility, int intelligence, int stamina);
        ICharacterBuilder SetLevel(int level);
        ICharacterBuilder AddAbility(string ability);
        ICharacterBuilder AddPassiveSkill(string skill);
        Character Build();
    }
}