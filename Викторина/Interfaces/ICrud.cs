using System;
using System.Collections.Generic;
using Викторина.Models;

namespace Викторина.Interfaces
{
    public interface ICrud
    {
        void Add(User user);
        IEnumerable<User> GetAll();
        User? GetById(Guid id);
        void Update(User user);
        void Delete(Guid id);
        void SaveChanges();
    }
}
//Add()               Добавить нового участника в список и сохранить в файл.
//GetAll()            Показать всех участников, которые есть в списке.
//GetById()           Найти участника по его уникальному номеру (ID).
//Update()            Изменить данные участника (например, баллы) и сохранить.
//Delete()            Удалить участника по его уникальному номеру (ID).
//SaveChanges()       Сохранить изменения в файл (JSON).    Загрузить данные из JSON-файла в память при запуске