using System;
using System.Collections.Generic;

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
            var passwordChars = new List<char>();
            while (true)
            {
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter) break;
                if (key.Key == ConsoleKey.Backspace && passwordChars.Count > 0)
                {
                    passwordChars.RemoveAt(passwordChars.Count - 1);
                    Console.Write("\b \b");
                }
                else if (!char.IsControl(key.KeyChar))
                {
                    passwordChars.Add(key.KeyChar);
                    Console.Write("*");
                }
            }
            Console.WriteLine();
            string password = new string(passwordChars.ToArray());
            // Очищаем список символов после создания строки
            for (int i = 0; i < passwordChars.Count; i++) passwordChars[i] = '\0';
            return password;
        }

        public static int ReadInt(string prompt, int min, int max)
        {
            while (true)
            {
                try
                {
                    Console.Write($"{prompt} ({min}-{max}): ");
                    if (int.TryParse(Console.ReadLine(), out int result) && result >= min && result <= max)
                    {
                        return result;
                    }
                    Error($"Пожалуйста, введите число от {min} до {max}.");
                }
                catch
                {
                    Error("Некорректный ввод. Попробуйте снова.");
                }
            }
        }

        public static void WaitForKey()
        {
            Print("\nНажмите любую клавишу для продолжения...");
            Console.ReadKey(true);
        }
    }
}
