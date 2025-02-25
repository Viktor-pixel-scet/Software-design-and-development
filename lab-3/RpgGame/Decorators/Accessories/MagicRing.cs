using RpgGame.Interfaces;

namespace RpgGame.Decorators.Accessories
{
    public class MagicRing : EquipmentDecorator
    {
        public MagicRing(IHero hero) : base(hero) { }

        public override string GetDescription() => $"{hero.GetDescription()} + Чарівний перстень";
        public override double GetMagicPower() => hero.GetMagicPower() + 3;
    }
}