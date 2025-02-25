using System;

namespace RpgGame.Interfaces
{
    public interface IHero
    {
        string GetDescription();
        double GetDamage();
        double GetDefense();
        double GetMagicPower();
    }
}