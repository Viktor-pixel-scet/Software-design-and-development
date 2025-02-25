using task_3;

namespace task_3
{
    public class Triangle : Shape
    {
        public Triangle(IRenderer renderer) : base(renderer) { }

        public override void Draw()
        {
            renderer.Render(shapeName);
        }
    }
}