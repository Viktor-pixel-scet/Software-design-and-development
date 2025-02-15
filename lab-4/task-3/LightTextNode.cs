using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_5
{
    public class LightTextNode : LightNode
    {
        private readonly string text;

        public LightTextNode(string text)
        {
            this.text = text ?? 
                throw new ArgumentNullException(nameof(text));
        }

        public override string OuterHTML => text;
        public override string InnerHTML => text;
    }
}
