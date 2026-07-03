using System;
using Викторина.Models;

try
{
    Menu.Show();
}
catch (Exception ex)
{
    Console.WriteLine($"Критическая ошибка приложения: {ex.Message}");
}

