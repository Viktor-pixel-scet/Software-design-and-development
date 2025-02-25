using RpgGame.Interfaces;

namespace RpgGame.Decorators.Armor
{
    public class Shield : EquipmentDecorator
    {
        public Shield(IHero hero) : base(hero) { }

        public override string GetDescription() => $"{hero.GetDescription()} + Щит";
        public override double GetDefense() => hero.GetDefense() + 3;
    }
}