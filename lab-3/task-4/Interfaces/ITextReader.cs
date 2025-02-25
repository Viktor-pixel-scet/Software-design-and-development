using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_4
{
    public interface ITextReader
    {
        char[][] ReadFile(string filePath);
    }
}
