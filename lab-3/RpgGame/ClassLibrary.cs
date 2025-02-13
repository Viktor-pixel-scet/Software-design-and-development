using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgGame
{
    public class Warrior : IHero
    {
        public string GetDescription() => "Воїн";
        public double GetDamage() => 10;
        public double GetDefense() => 8;
        public double GetMagicPower() => 0;
    }


    public class Mage : IHero
    {
        public string GetDescription() => "Маг";
        public double GetDamage() => 4;
        public double GetDefense() => 3;
        public double GetMagicPower() => 15;
    }

    public class Paladin : IHero
    {
        public string GetDescription() => "Паладин";
        public double GetDamage() => 7;
        public double GetDefense() => 10;
        public double GetMagicPower() => 5;
    }
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

    public class Sword : EquipmentDecorator
    {
        public Sword(IHero hero) : base(hero) { }

        public override string GetDescription() => $"{hero.GetDescription()} + Меч";
        public override double GetDamage() => hero.GetDamage() + 5;
    }


    public class Staff : EquipmentDecorator
    {
        public Staff(IHero hero) : base(hero) { }

        public override string GetDescription() => $"{hero.GetDescription()} + Посох";
        public override double GetDamage() => hero.GetDamage() + 2;
        public override double GetMagicPower() => hero.GetMagicPower() + 7;
    }


    public class Armor : EquipmentDecorator
    {
        public Armor(IHero hero) : base(hero) { }

        public override string GetDescription() => $"{hero.GetDescription()} + Броня";
        public override double GetDefense() => hero.GetDefense() + 5;
    }

    public class Shield : EquipmentDecorator
    {
        public Shield(IHero hero) : base(hero) { }

        public override string GetDescription() => $"{hero.GetDescription()} + Щит";
        public override double GetDefense() => hero.GetDefense() + 3;
    }
    public class MagicRing : EquipmentDecorator
    {
        public MagicRing(IHero hero) : base(hero) { }

        public override string GetDescription() => $"{hero.GetDescription()} + Чарівний перстень";
        public override double GetMagicPower() => hero.GetMagicPower() + 3;
    }
}
