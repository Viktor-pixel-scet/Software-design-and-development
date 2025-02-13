using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgGame
{
    public interface IHero
    {
        string GetDescription();
        double GetDamage();
        double GetDefense();
        double GetMagicPower();
    }
}
