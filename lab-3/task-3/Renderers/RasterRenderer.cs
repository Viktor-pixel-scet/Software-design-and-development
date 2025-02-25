using System;

namespace task_3
{
    public class RasterRenderer : IRenderer
    {
        public void Render(string shape)
        {
            Console.WriteLine($"Малюємо {shape} як растрове");
        }
    }
}