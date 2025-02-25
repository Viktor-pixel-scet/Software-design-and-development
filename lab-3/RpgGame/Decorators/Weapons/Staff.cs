using RpgGame.Interfaces;

namespace RpgGame.Decorators.Weapons
{
    public class Staff : EquipmentDecorator
    {
        public Staff(IHero hero) : base(hero) { }

        public override string GetDescription() => $"{hero.GetDescription()} + Посох";
        public override double GetDamage() => hero.GetDamage() + 2;
        public override double GetMagicPower() => hero.GetMagicPower() + 7;
    }
}