using System;
using System.Collections.Generic;
using Викторина.Models;

namespace Викторина.Interfaces
{

    public interface ICrud
    {
        void Add(Registration registration); 
        IEnumerable<Registration> GetAll();
        Registration? GetById(Guid id);
        void Password(string password);
        void RegistrationDate(DateTime date);
        void Login();
        void Update(Registration registration);
        void Delete(Guid id);
        void Load();
        void SaveChanges();

    }
}
//Add()               Добавить нового участника в список и сохранить в файл.
//GetAll()            Показать всех участников, которые есть в списке.
//GetById()           Найти участника по его уникальному номеру (ID).
//Password()          Изменить пароль участника.
//RegistrationDate()  Установить дату регистрации участника.
//Login()             Вход в систему (проверка логина и пароля).
//Update()            Изменить данные участника (например, баллы) и сохранить.
//Delete()            Удалить участника по его уникальному номеру (ID).
//Load()              Загрузить данные из файла (JSON) в память.
//SaveChanges()       Сохранить изменения в файл (JSON).    Загрузить данные из JSON-файла в память при запуске