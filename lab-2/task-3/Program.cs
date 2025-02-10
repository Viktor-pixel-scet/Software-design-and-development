using System;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Collections.Generic;

public static class ConsoleHelper
{
    public static void WriteSuccess(string message)
    {
        var originalColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"{message}");
        Console.ForegroundColor = originalColor;
    }

    public static void WriteError(string message)
    {
        var originalColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"{message}");
        Console.ForegroundColor = originalColor;
    }

    public static void WriteInfo(string message)
    {
        var originalColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"{message}");
        Console.ForegroundColor = originalColor;
    }

    public static void WriteHeader(string header)
    {
        Console.WriteLine();
        var originalColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"{"═".PadRight(50, '═')}");
        Console.WriteLine($"  {header}");
        Console.WriteLine($"{"═".PadRight(50, '═')}");
        Console.ForegroundColor = originalColor;
        Console.WriteLine();
    }
}

public interface IAuthenticator
{
    Task<bool> AuthenticateAsync(string userId, string password);
    void LogOut(string userId);
}

public sealed class Authenticator : IAuthenticator
{
    private static readonly Lazy<Authenticator> instance =
        new Lazy<Authenticator>(() => new Authenticator(), true);

    private readonly Dictionary<string, DateTime> activeSessions;
    private readonly TimeSpan sessionTimeout = TimeSpan.FromMinutes(30);

    private Authenticator()
    {
        activeSessions = new Dictionary<string, DateTime>();
        ConsoleHelper.WriteInfo("Ініціалізовано автентифікатор");
    }

    public static Authenticator Instance => instance.Value;

    public async Task<bool> AuthenticateAsync(string userId, string password)
    {
        if (string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(password))
        {
            throw new ArgumentException("UserId та пароль не можуть бути порожніми");
        }

        await Task.Delay(100);

        try
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedPassword = Convert.ToBase64String(
                    sha256.ComputeHash(Encoding.UTF8.GetBytes(password))
                );

                lock (activeSessions)
                {
                    activeSessions[userId] = DateTime.UtcNow;
                }

                ConsoleHelper.WriteSuccess($"Користувач {userId} успішно автентифіковано");
                return true;
            }
        }
        catch (Exception ex)
        {
            ConsoleHelper.WriteError($"Помилка автентифікації користувача {userId}: {ex.Message}");
            return false;
        }
    }

    public void LogOut(string userId)
    {
        lock (activeSessions)
        {
            if (activeSessions.Remove(userId))
            {
                ConsoleHelper.WriteSuccess($"Користувач {userId} успішно вийшов з системи");
            }
        }
    }

    public bool IsSessionValid(string userId)
    {
        lock (activeSessions)
        {
            if (activeSessions.TryGetValue(userId, out DateTime lastActivity))
            {
                var isValid = DateTime.UtcNow - lastActivity <= sessionTimeout;
                if (!isValid)
                {
                    activeSessions.Remove(userId);
                    ConsoleHelper.WriteError($"У користувача {userId} закінчився термін дії сесії");
                }
                return isValid;
            }
            return false;
        }
    }
}

public class Program
{
    static async Task Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        ConsoleHelper.WriteHeader("Тест 1: Перевірка єдиного екземпляру");
        var auth1 = Authenticator.Instance;
        var auth2 = Authenticator.Instance;
        ConsoleHelper.WriteInfo($"Екземпляри ідентичні: {ReferenceEquals(auth1, auth2)}");

        ConsoleHelper.WriteHeader("Тест 2: Перевірка багатопоточної аутентифікації");
        var tasks = new List<Task>();
        for (int i = 0; i < 5; i++)
        {
            string userId = $"User_{i}";
            string password = $"Password_{i}";

            tasks.Add(Task.Run(async () =>
            {
                var auth = Authenticator.Instance;
                bool result = await auth.AuthenticateAsync(userId, password);
                if (result)
                    ConsoleHelper.WriteSuccess($"Аутентифікація для {userId}: успішна");
                else
                    ConsoleHelper.WriteError($"Аутентифікація для {userId}: невдала");

                bool isValid = auth.IsSessionValid(userId);
                if (isValid)
                    ConsoleHelper.WriteSuccess($"Сесія для {userId}: активна");
                else
                    ConsoleHelper.WriteError($"Сесія для {userId}: неактивна");
            }));
        }
        await Task.WhenAll(tasks);

        ConsoleHelper.WriteHeader("Тест 3: Перевірка виходу з системи");
        var testUser = "TestUser";
        await Authenticator.Instance.AuthenticateAsync(testUser, "TestPassword");

        bool sessionActive = Authenticator.Instance.IsSessionValid(testUser);
        ConsoleHelper.WriteInfo($"Сесія активна: {sessionActive}");

        Authenticator.Instance.LogOut(testUser);
        sessionActive = Authenticator.Instance.IsSessionValid(testUser);
        ConsoleHelper.WriteInfo($"Сесія після виходу: {sessionActive}");

        ConsoleHelper.WriteHeader("Тест 4: Перевірка невалідних даних");
        try
        {
            // Микола Олександрович, як будете перевіряти, то тут вводиться UserID and password
            await Authenticator.Instance.AuthenticateAsync("", "");
        }
        catch (ArgumentException ex)
        {
            ConsoleHelper.WriteError($"Очікувана помилка: {ex.Message}\n");
        }
    }
}