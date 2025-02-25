using RpgGame.Interfaces;

namespace RpgGame.Heroes
{
    public class Paladin : IHero
    {
        public string GetDescription() => "Паладин";
        public double GetDamage() => 7;
        public double GetDefense() => 10;
        public double GetMagicPower() => 5;
    }
}