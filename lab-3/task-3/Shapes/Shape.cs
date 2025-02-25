using System;
using task_3;

namespace task_3
{
    public abstract class Shape
    {
        protected IRenderer renderer;
        protected string shapeName;

        public Shape(IRenderer renderer)
        {
            this.renderer = renderer;
            this.shapeName = GetType().Name;
        }

        public abstract void Draw();
    }
}