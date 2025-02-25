using RpgGame.Interfaces;

namespace RpgGame.Decorators.Armor
{
    public class Armor : EquipmentDecorator
    {
        public Armor(IHero hero) : base(hero) { }

        public override string GetDescription() => $"{hero.GetDescription()} + Броня";
        public override double GetDefense() => hero.GetDefense() + 5;
    }
}