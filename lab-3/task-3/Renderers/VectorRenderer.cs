using System;

namespace task_3
{
    public class VectorRenderer : IRenderer
    {
        public void Render(string shape)
        {
            Console.WriteLine($"Малюємо {shape} як вектор");
        }
    }
}