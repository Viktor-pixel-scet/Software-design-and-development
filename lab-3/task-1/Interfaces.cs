using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface ILogger
    {
        void Log (string message);
        void Error (string message);
        void Warn (string message);
    }

    public interface IfileWriter
    {
        void Write (string message);
        void WriteLine (string message);
    }
}
