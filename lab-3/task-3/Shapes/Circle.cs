using task_3;

namespace task_3
{
    public class Circle : Shape
    {
        public Circle(IRenderer renderer) : base(renderer) { }

        public override void Draw()
        {
            renderer.Render(shapeName);
        }
    }
}