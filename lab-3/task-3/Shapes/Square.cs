using task_3;

namespace task_3
{
    public class Square : Shape
    {
        public Square(IRenderer renderer) : base(renderer) { }

        public override void Draw()
        {
            renderer.Render(shapeName);
        }
    }
}