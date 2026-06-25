using System;
using System.Collections.Generic;
using Викторина.Models;

namespace Викторина.Interfaces
{

    public interface ICrud
    {
        public void Add(Registration registration); 
        public IEnumerable<Registration> GetAll();
        public void Update(Registration registration);
        public void Delete(Guid id);
        public void Load();
    }
}
//Add()   ➕ Добавить нового участника в список и сохранить в файл.
//GetAll()	📋 Показать всех участников, которые есть в списке.
//Update()	✏️ Изменить данные участника (например, баллы) и сохранить.
//Delete()	🗑️ Удалить участника по его уникальному номеру (ID).
//Load()	📂 Загрузить данные из JSON-файла в память при запуске