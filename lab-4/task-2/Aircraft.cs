using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_2
{
    public class Aircraft
    {
        private IAirportMediator _mediator;
        public string Name { get; }
        public bool IsLanded { get; private set; }

        public Aircraft(string name, int size)
        {
            Name = name;
            IsLanded = false;
        }

        public void SetMediator(IAirportMediator mediator)
        {
            _mediator = mediator;
        }

        public void Land()
        {
            if (!IsLanded && _mediator.RequestLanding(this))
            {
                IsLanded = true;
                Console.WriteLine($"Літак {Name} успішно приземлився\n");
            }
        }

        public void TakeOff()
        {
            if (IsLanded && _mediator.RequestTakeoff(this))
            {
                IsLanded = false;
                Console.WriteLine($"Літак {Name} успішно злетів\n");
            }
        }
    }
}