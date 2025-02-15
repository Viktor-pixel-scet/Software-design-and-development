
namespace task_4
{
    public interface IImageLoadStrategy
    {
        Task LoadImageAsync(string path);
    }
}
