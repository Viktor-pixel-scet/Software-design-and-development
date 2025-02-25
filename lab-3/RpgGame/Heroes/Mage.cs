using RpgGame.Interfaces;

namespace RpgGame.Heroes
{
    public class Mage : IHero
    {
        public string GetDescription() => "Маг";
        public double GetDamage() => 4;
        public double GetDefense() => 3;
        public double GetMagicPower() => 15;
    }
}