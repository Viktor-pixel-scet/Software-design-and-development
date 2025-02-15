using System.Text;

namespace task_5
{
    public delegate void EventHandler(string eventType);

    public class LightElementNode : LightNode
    {
        private readonly List<LightNode> children;
        private readonly HashSet<string> cssClasses;
        private readonly Dictionary<string, List<EventHandler>> eventListeners;

        public string TagName { get; }
        public DisplayType Display { get; }
        public ClosingType Closing { get; }
        public IReadOnlyCollection<string> CssClasses => cssClasses;
        public int ChildCount => children.Count;

        public LightElementNode(
            string tagName,
            DisplayType display = DisplayType.Block,
            ClosingType closing = ClosingType.Normal)
        {
            TagName = tagName ??
                throw new ArgumentNullException(nameof(tagName));
            Display = display;
            Closing = closing;
            children = new List<LightNode>();
            cssClasses = new HashSet<string>();
            eventListeners = new Dictionary<string, List<EventHandler>>();
        }

        public void AddChild(LightNode child)
        {
            children.Add(child ??
                throw new ArgumentNullException(nameof(child)));
        }

        public void AddCssClass(string cssClass)
        {
            if (string.IsNullOrWhiteSpace(cssClass))
                throw new ArgumentException("CSS клас не може бути порожнім", nameof(cssClass));
            cssClasses.Add(cssClass);
        }

        public void AddEventListener(string eventType, EventHandler handler)
        {
            if (string.IsNullOrWhiteSpace(eventType))
                throw new ArgumentException("Тип події не може бути порожнім", nameof(eventType));

            if (handler == null)
                throw new ArgumentNullException(nameof(handler));

            var validEvents = new[] { "click", "mouseover", "mouseout", "keypress", "keydown", "keyup" };
            if (!validEvents.Contains(eventType.ToLower()))
                throw new ArgumentException($"Непідтримуваний тип події: {eventType}", nameof(eventType));

            if (!eventListeners.ContainsKey(eventType))
                eventListeners[eventType] = new List<EventHandler>();

            if (!eventListeners[eventType].Contains(handler))
                eventListeners[eventType].Add(handler);
        }

        public void TriggerEvent(string eventType)
        {
            if (eventListeners.TryGetValue(eventType, out var handlers))
            {
                foreach (var handler in handlers)
                {
                    handler(eventType);
                }
            }

            foreach (var child in children)
            {
                if (child is LightElementNode elementNode)
                {
                    elementNode.TriggerEvent(eventType);
                }
            }
        }

        public override string OuterHTML => GenerateHTML(0);
        public override string InnerHTML => GenerateHTML(0, innerOnly: true);

        private string GenerateHTML(int indentLevel, bool innerOnly = false)
        {
            var sb = new StringBuilder();
            string indent = new string(' ', indentLevel * 2);
            bool isStyle = TagName.Equals("style", StringComparison.OrdinalIgnoreCase);

            if (!innerOnly)
            {
                sb.Append(indent).Append('<').Append(TagName);

                if (cssClasses.Any())
                {
                    sb.Append(" class=\"")
                      .Append(string.Join(" ", cssClasses))
                      .Append('"');
                }

                foreach (var eventType in eventListeners.Keys)
                {
                    sb.Append($" on{eventType}=\"javascript:void(0);\"");
                }

                if (Closing == ClosingType.SelfClosing)
                {
                    sb.AppendLine(" />");
                    return sb.ToString();
                }

                sb.AppendLine(">");
            }

            if (isStyle)
            {
                foreach (var child in children)
                {
                    var lines = child.OuterHTML.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var line in lines)
                    {
                        sb.Append(indent).Append("  ").AppendLine(line.Trim());
                    }
                }
            }
            else
            {
                foreach (var child in children)
                {
                    if (child is LightTextNode)
                    {
                        sb.Append(indent).Append("  ").AppendLine(child.OuterHTML);
                    }
                    else
                    {
                        sb.Append(((LightElementNode)child).GenerateHTML(indentLevel + 1));
                    }
                }
            }

            if (!innerOnly && Closing == ClosingType.Normal)
            {
                sb.Append(indent).Append("</").Append(TagName).AppendLine(">");
            }

            return sb.ToString();
        }
    }
}
