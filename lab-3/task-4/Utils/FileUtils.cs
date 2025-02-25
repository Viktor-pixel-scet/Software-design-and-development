using System;
using System.IO;
using System.Text;

namespace task_4
{
    public static class FileUtils
    {
        public static void PrepareTestFiles()
        {
            var testDir = "test_files";
            if (!Directory.Exists(testDir))
            {
                Directory.CreateDirectory(testDir);
            }

            string publicContent = @"Звіт про виконану роботу
Відділ: Розробки програмного забезпечення
Дата: 14 лютого 2025 року

За звітний період виконано:
1. Завершення розробки модуля авторизації користувачів
2. Оптимізація запитів до бази даних
3. Впровадження нової системи логування помилок
4. Оновлення документації API

Загальна ефективність роботи відділу зросла на 12% порівняно з минулим кварталом😎
Заплановані задачі на наступний місяць включають інтеграцію з системою аналітики та розробку нових звітів!";

            string confidentialContent = @"КОНФІДЕНЦІЙНО
Звіт відділу безпеки
Дата: 12 лютого 2025 року

Виявлені вразливості:
1. Критична вразливість у системі авторизації (CVE-2025-7891)
2. Потенційний витік даних через незахищений API-ендпоінт
3. Слабкі паролі виявлені у 17% користувачів системи

План виправлення:
- Негайне оновлення авторизаційного модуля до версії 2.1.5
- Впровадження додаткової автентифікації для критичних ендпоінтів
- Запуск кампанії з оновлення паролів для всіх співробітників

Інцидент №458: Спроба несанкціонованого доступу з IP 192.168.1.45
Час: 10.02.2025, 03:15
Статус: Заблоковано, проводиться розслідування";

            File.WriteAllText(Path.Combine(testDir, "allowed.txt"), publicContent, Encoding.UTF8);
            File.WriteAllText(Path.Combine(testDir, "restricted.txt"), confidentialContent, Encoding.UTF8);
        }

        public static void PrintTextArray(char[][] array)
        {
            if (array == null || array.Length == 0)
            {
                Console.WriteLine("Масив порожній або не визначений");
                return;
            }

            Console.WriteLine("\n--- Прочитаний текст ---");
            foreach (var row in array)
            {
                Console.WriteLine(new string(row));
            }
            Console.WriteLine("----------------------\n");
        }
    }
}