using System.Text;

namespace task_5;
public struct TextStyle
{
    public ConsoleColor TextColor { get; set; }
    public ConsoleColor BackgroundColor { get; set; }
    public bool IsBold { get; set; }
    public bool IsUnderline { get; set; }

    public TextStyle(ConsoleColor textColor, ConsoleColor backgroundColor, bool isBold = false, bool isUnderline = false)
    {
        TextColor = textColor;
        BackgroundColor = backgroundColor;
        IsBold = isBold;
        IsUnderline = isUnderline;
    }
}

public class Program
{
    public static async Task Main()
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        Console.InputEncoding = Encoding.GetEncoding("Windows-1251");
        Console.OutputEncoding = Encoding.UTF8;

        Console.Title = "Розширений текстовий редактор";
        var editor = new TextEditor();
        bool isRunning = true;

        Console.SetWindowSize(
            Math.Min(Console.LargestWindowWidth, 120),
            Math.Min(Console.LargestWindowHeight, 40)
        );
        Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);

        Console.CancelKeyPress += (sender, e) =>
        {
            e.Cancel = true;
            isRunning = false;
        };

        try
        {
            while (isRunning)
            {
                editor.DisplayCurrentState();

                var keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.Escape)
                {
                    Console.SetCursorPosition(0, Console.WindowHeight - 2);
                    Console.Write("Зберегти зміни перед виходом?\n");
                    Console.Write("[Y] - Так, зберегти\n");
                    Console.Write("[N] - Ні, вийти без збереження\n");
                    Console.Write("[C] - Скасувати вихід\n");
                    Console.Write("Ваш вибір: ");

                    var response = Console.ReadKey(true);

                    switch (response.Key)
                    {
                        case ConsoleKey.Y:
                            editor.ShowTooltip("Save");
                            editor.SaveToFile("backup.txt");
                            isRunning = false;
                            break;
                        case ConsoleKey.N:
                            isRunning = false;
                            break;
                        default:
                            continue;
                    }
                }
                else
                {
                    editor.ProcessKeyPress(keyInfo);
                }
            }
        }
        finally
        {
            Console.ResetColor();
            Console.Clear();
            Console.WriteLine("Дякуємо за використання редактора!");
        }
    }
}