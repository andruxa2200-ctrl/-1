using System;
using Викторина.Models;
using Викторина.Cabinet;

try
{
    Menu.Show();
}
catch (Exception ex)
{
    Console.WriteLine($"Критическая ошибка приложения: {ex.Message}");
}

