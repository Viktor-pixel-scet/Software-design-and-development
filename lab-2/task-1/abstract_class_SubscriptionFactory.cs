using Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_2
{
    public abstract class SubscriptionFactory
    {
        public abstract ISubscription CreateSubscription();
    }
}
