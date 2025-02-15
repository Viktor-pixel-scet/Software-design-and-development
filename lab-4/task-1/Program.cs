namespace task_1;

public class Program
{
    public static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        var supportSystem = new SupportSystem();
        supportSystem.ProcessRequest();
    }
}