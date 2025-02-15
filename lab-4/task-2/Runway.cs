
namespace task_2
{
    public class Runway
    {
        private IAirportMediator _mediator;
        public readonly Guid Id = Guid.NewGuid();
        public bool IsBusy { get; private set; }

        public void SetMediator(IAirportMediator mediator)
        {
            _mediator = mediator;
        }

        public void SetBusy()
        {
            IsBusy = true;
            Console.WriteLine($"Злітно-посадкова смуга {Id} зараз зайнято!\n");
        }

        public void SetFree()
        {
            IsBusy = false;
            Console.WriteLine($"Злітна смуга {Id} тепер вільна!\n");
        }
    }
}