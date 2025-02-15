
namespace task_4
{
    public class FileSystemImageLoadStrategy : IImageLoadStrategy
    {
        public async Task LoadImageAsync(string path)
        {
            Console.WriteLine($"Спроба завантажити файл з: {path}");
            Console.WriteLine($"Перевірка існування файлу: {File.Exists(path)}");
            Console.WriteLine($"Поточна директорія: {Directory.GetCurrentDirectory()}");

            if (!File.Exists(path))
            {
                string? directory = Path.GetDirectoryName(path);
                if (directory != null && !Directory.Exists(directory))
                {
                    throw new DirectoryNotFoundException($"Директорію не знайдено: {directory}");
                }
                throw new FileNotFoundException($"Файл зображення не знайдено за шляхом: {path}");
            }

            await Task.Delay(1000);
            Console.WriteLine($"Успішно завантажено зображення з файлової системи: {path}");
        }
    }

    public class NetworkImageLoadStrategy : IImageLoadStrategy
    {
        private readonly HttpClient _httpClient;

        public NetworkImageLoadStrategy()
        {
            _httpClient = new HttpClient();
        }

        public async Task LoadImageAsync(string url)
        {
            try
            {
                var response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                Console.WriteLine($"Успішно завантажено зображення з мережі: {url}");
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Не вдалося завантажити зображення за URL: {url}", ex);
            }
        }
    }

    public class ImageLoadStrategyFactory
    {
        public static IImageLoadStrategy CreateStrategy(string path)
        {
            if (Uri.TryCreate(path, UriKind.Absolute, out Uri? uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps))
            {
                return new NetworkImageLoadStrategy();
            }

            return new FileSystemImageLoadStrategy();
        }
    }

    public class Image
    {
        private IImageLoadStrategy? loadStrategy;

        public async Task LoadAsync(string path)
        {
            loadStrategy = ImageLoadStrategyFactory.CreateStrategy(path);
            await loadStrategy.LoadImageAsync(path);
        }
    }
    public class ImageProcessor
    {
        private readonly Image imageLoader;

        public ImageProcessor()
        {
            imageLoader = new Image();
        }

        public async Task ProcessImageFromAnySource(string imagePath)
        {
            try
            {
                await imageLoader.LoadAsync(imagePath);
                Console.WriteLine("Image processing completed successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка обробки зображення: {ex.Message}");
            }
        }
    }
}
