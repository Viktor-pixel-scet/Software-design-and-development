using System;

namespace Interfaces
{
    public interface IfileWriter
    {
        void Write(string message);
        void WriteLine(string message);
    }
}