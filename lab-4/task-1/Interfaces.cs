using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_1
{
    public interface ISupportHandler
    {
        void SetNext(ISupportHandler handler);
        void Handle(string request);
        void DisplayMenu();
    }

    public interface ILogger
    {
        void Log(string message);
    }
}
