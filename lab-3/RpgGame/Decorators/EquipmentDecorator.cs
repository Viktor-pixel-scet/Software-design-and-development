using RpgGame.Interfaces;

namespace RpgGame.Decorators
{
    public abstract class EquipmentDecorator : IHero
    {
        protected IHero hero;

        public EquipmentDecorator(IHero hero)
        {
            this.hero = hero;
        }

        public virtual string GetDescription() => hero.GetDescription();
        public virtual double GetDamage() => hero.GetDamage();
        public virtual double GetDefense() => hero.GetDefense();
        public virtual double GetMagicPower() => hero.GetMagicPower();
    }
}