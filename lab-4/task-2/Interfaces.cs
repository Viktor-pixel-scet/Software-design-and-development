using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_2
{
    public interface IAirportMediator
    {
        bool RequestLanding(Aircraft aircraft);
        bool RequestTakeoff(Aircraft aircraft);
        Runway GetAvailableRunway();
    }
}
