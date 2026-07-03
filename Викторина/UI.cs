using System;

namespace Викторина
{
    public static class UI
    {
        public static void Print(string message) => Console.WriteLine(message);
        
        public static void Clear() => Console.Clear();

        public static void Error(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[ОШИБКА]: {message}");
            Console.ResetColor();
        }

        public static void Success(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public static string ReadString(string prompt)
        {
            while (true)
            {
                Console.Write($"{prompt}: ");
                string? input = Console.ReadLine()?.Trim();
                if (!string.IsNullOrWhiteSpace(input)) return input;
                Error("Поле не может быть пустым. Выберете снова.");
            }
        }

        public static string ReadPassword(string prompt)
        {
            Console.Write($"{prompt}: ");
            string password = string.Empty;
            while (true)
            {
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter) break;
                if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                {
                    password = password[..^1];
                    Console.Write("\b \b");
                }
                else if (!char.IsControl(key.KeyChar))
                {
                    password += key.KeyChar;
                    Console.Write("*");
                }
            }
            Console.WriteLine();
            return password;
        }

        public static void WaitForKey()
        {
            Print("\nНажмите любую клавишу для продолжения...");
            Console.ReadKey(true);
        }
    }
}
