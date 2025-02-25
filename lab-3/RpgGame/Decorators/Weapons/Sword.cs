using RpgGame.Interfaces;

namespace RpgGame.Decorators.Weapons
{
    public class Sword : EquipmentDecorator
    {
        public Sword(IHero hero) : base(hero) { }

        public override string GetDescription() => $"{hero.GetDescription()} + Меч";
        public override double GetDamage() => hero.GetDamage() + 5;
    }
}