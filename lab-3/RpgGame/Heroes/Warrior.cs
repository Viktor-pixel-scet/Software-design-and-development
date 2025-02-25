using RpgGame.Interfaces;

namespace RpgGame.Heroes
{
    public class Warrior : IHero
    {
        public string GetDescription() => "Воїн";
        public double GetDamage() => 10;
        public double GetDefense() => 8;
        public double GetMagicPower() => 0;
    }
}