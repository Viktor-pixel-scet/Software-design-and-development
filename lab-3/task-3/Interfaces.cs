using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_3
{
    public interface IRenderer
    {
        void Render(string shape);
    }

    public class VectorRenderer : IRenderer
    {
        public void Render(string shape)
        {
            Console.WriteLine($"Малюємо {shape} як вектор");
        }
    }

    public class RasterRenderer : IRenderer
    {
        public void Render(string shape)
        {
            Console.WriteLine($"Малюємо {shape} як растрове");
        }
    }
}
