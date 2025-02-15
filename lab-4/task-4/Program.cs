
namespace task_4;

public class Program
{
    public static async Task Main()
    {
        try
        {
            Image image = new Image();

            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string projectDirectory = Path.GetFullPath(Path.Combine(baseDirectory, @"..\..\..\..\"));
            string imagePath = Path.Combine(projectDirectory, "task-4", "Q75ggES7Mbv87lMk6iHHsA.jpeg");

            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine($"Базова директорія: {baseDirectory}");
            Console.WriteLine($"Директорія проекту: {projectDirectory}");
            Console.WriteLine($"Повний шлях до зображення: {imagePath}");

            Console.WriteLine("\nТестування завантаження з файлової системи:");
            if (File.Exists(imagePath))
            {
                await image.LoadAsync(imagePath);
            }
            else
            {
                Console.WriteLine($"Файл не існує за шляхом: {imagePath}");
                Console.WriteLine("Будь ласка, перевірте чи файл існує у вказаній папці");
            }

            Console.WriteLine("\nТестування завантаження з мережі:");
            await image.LoadAsync("https://static-cse.canva.com/blob/191106/00_verzosa_winterlandscapes_jakob-owens-tb-2640x1485.jpg");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nПомилка: {ex.Message}");
        }
        finally
        {
            Console.WriteLine("\nНатисніть будь-яку клавішу для завершення...");
            Console.ReadKey();
        }
    }
}