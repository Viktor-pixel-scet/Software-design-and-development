using System.Text;
using task_5;

namespace LightHTML
{
    public class Program
    {
        public static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            var container = CreateHTMLStructure();

            Console.WriteLine("=== Згенерована HTML структура ===\n");
            Console.WriteLine(container.OuterHTML);

            Console.WriteLine("=== Інформація про структуру ===");
            Console.WriteLine($"Загальна кількість елементів: {container.ChildCount}");
            Console.WriteLine($"CSS класи контейнера: {string.Join(", ", container.CssClasses)}");
        }

        private static LightElementNode CreateHTMLStructure()
        {
            var container = new LightElementNode("div");
            container.AddCssClass("container");

            var style = new LightElementNode("style");
            style.AddChild(new LightTextNode(@"
                                                .container {
                                                    max-width: 800px;
                                                    margin: 20px auto;
                                                    font-family: 'Segoe UI', Tahoma, sans-serif;
                                                    background: white;
                                                    padding: 20px;
                                                    border-radius: 10px;
                                                    box-shadow: 0 0 20px rgba(0,0,0,0.1);
                                               }
                                                .header {
                                                    color: #2c3e50;
                                                    text-align: center;
                                                    padding-bottom: 20px;
                                                    border-bottom: 2px solid #eee;
                                                    margin-bottom: 20px;
                                                }
                                                .course-list {
                                                    list-style: none;
                                                    padding: 0;
                                                }
                                                .course-item {
                                                    background: #f8f9fa;
                                                    margin: 10px 0;
                                                    padding: 15px;
                                                    border-radius: 5px;
                                                    border-left: 4px solid #3498db;
                                                    transition: transform 0.2s;
                                                }
                                                .course-item:hover {
                                                    transform: translateX(10px);
                                                }
                                                .info-section {
                                                    background: #e8f4f8;
                                                    padding: 15px;
                                                    border-radius: 5px;
                                                    margin-top: 20px;
                                                }
                                                .info-text {
                                                    color: #444;
                                                    line-height: 1.6;
                                                }
                                                .link {
                                                    color: #3498db;
                                                    text-decoration: none;
                                                    font-weight: bold;
                                                }
                                                .link:hover {
                                                    text-decoration: underline;
                                                }
                                                .stats {
                                                    display: flex;
                                                    justify-content: space-around;
                                                    margin-top: 20px;
                                                    padding: 20px 0;
                                                    border-top: 2px solid #eee;
                                                }
                                                .stat-item {
                                                    text-align: center;
                                                }
                                                .stat-value {
                                                    font-size: 24px;
                                                    font-weight: bold;
                                                    color: #2c3e50;
                                                }
                                                .stat-label {
                                                    color: #7f8c8d;
                                                    font-size: 14px;
                                                }"));

            container.AddChild(style);

            var header = new LightElementNode("div");
            header.AddCssClass("header");
            var h1 = new LightElementNode("h1");
            h1.AddChild(new LightTextNode("Курси програмування"));
            header.AddChild(h1);
            container.AddChild(header);

            var list = new LightElementNode("ul");
            list.AddCssClass("course-list");

            var courses = new[]
            {
                "Frontend розробка (HTML, CSS, JavaScript)",
                "Backend розробка (C#, .NET Core, SQL)",
                "Розробка мобільних додатків (React Native)",
                "DevOps практики та інструменти"
            };

            foreach (var course in courses)
            {
                var li = new LightElementNode("li");
                li.AddCssClass("course-item");
                li.AddChild(new LightTextNode(course));
                list.AddChild(li);
            }
            container.AddChild(list);

            var infoSection = new LightElementNode("div");
            infoSection.AddCssClass("info-section");

            var infoText = new LightElementNode("p");
            infoText.AddCssClass("info-text");
            infoText.AddChild(new LightTextNode("Наші курси розроблені досвідченими розробниками та включають практичні завдання "));

            var link = new LightElementNode("a", DisplayType.Inline);
            link.AddCssClass("link");
            link.AddChild(new LightTextNode("Дізнатися більше"));
            infoText.AddChild(link);

            infoSection.AddChild(infoText);
            container.AddChild(infoSection);

            var stats = new LightElementNode("div");
            stats.AddCssClass("stats");

            var statsData = new[]
            {
                ("500+", "Студентів"),
                ("50+", "Курсів"),
                ("98%", "Працевлаштування")
            };

            foreach (var (value, label) in statsData)
            {
                var statItem = new LightElementNode("div");
                statItem.AddCssClass("stat-item");

                var statValue = new LightElementNode("div");
                statValue.AddCssClass("stat-value");
                statValue.AddChild(new LightTextNode(value));

                var statLabel = new LightElementNode("div");
                statLabel.AddCssClass("stat-label");
                statLabel.AddChild(new LightTextNode(label));

                statItem.AddChild(statValue);
                statItem.AddChild(statLabel);
                stats.AddChild(statItem);
            }

            container.AddChild(stats);

            return container;
        }
    }
}