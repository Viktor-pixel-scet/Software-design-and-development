using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task_2;

namespace Interfaces
{
    public interface IDevice
    {
        string Brand { get; }
        decimal Price { get; }
        string Specifications { get; }
        void ShowInfo();
    }
}
