using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_2
{
    public class CommandCentre : IAirportMediator
    {
        private readonly List<Runway> _runways = new List<Runway>();
        private readonly List<Aircraft> _aircrafts = new List<Aircraft>();

        public CommandCentre(Runway[] runways, Aircraft[] aircrafts)
        {
            this._runways.AddRange(runways);
            this._aircrafts.AddRange(aircrafts);

            foreach (var runway in runways)
            {
                runway.SetMediator(this);
            }
            foreach (var aircraft in aircrafts)
            {
                aircraft.SetMediator(this);
            }
        }

        public bool RequestLanding(Aircraft aircraft)
        {
            Console.WriteLine($"Літак {aircraft.Name} запит на дозвіл на посадку\n");
            var runway = GetAvailableRunway();

            if (runway != null)
            {
                Console.WriteLine($"Надано дозвіл на посадку повітряного судна {aircraft.Name}\n");
                runway.SetBusy();
                return true;
            }

            Console.WriteLine($"Відмовлено в посадці літака {aircraft.Name} - немає вільних злітно-посадкових смуг\n");
            return false;
        }

        public bool RequestTakeoff(Aircraft aircraft)
        {
            Console.WriteLine($"Літак {aircraft.Name} запит на дозвіл на зліт\n");
            var runway = _runways.Find(r => r.IsBusy);

            if (runway != null)
            {
                Console.WriteLine($"Надано дозвіл на зліт повітряного судна {aircraft.Name}\n");
                runway.SetFree();
                return true;
            }

            Console.WriteLine($"Відмовлено у зльоті літака {aircraft.Name}\n");
            return false;
        }

        public Runway GetAvailableRunway()
        {
            return _runways.Find(r => !r.IsBusy);
        }
    }
}