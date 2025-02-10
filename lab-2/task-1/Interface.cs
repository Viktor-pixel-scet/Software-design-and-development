using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    public interface ISubscription
    {
        string Name
        {
            get;
        }
        decimal MonthlyFee
        {
            get;
        }
        int MinPeriod
        {
            get;
        }
        List<string> Channels
        {
            get;
        }
        void GetInfo();
    }
}
