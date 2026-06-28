using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Викторина.Models;
using Викторина.Interfaces;

namespace Викторина.Data;

//Отвечает за ХРАНЕНИЕ книг(данных) и работу с файлами
public class JsonContext : ICrud
{   
    public JsonContext(string pathToJson)
    {
        PathToJson = pathToJson;
    }
    public JsonContext()
    {
        PathToJson = "contacts.json"; 
    }
    private readonly List<Registration> _contacts = [];
    private bool _isLoaded = false;
    public string PathToJson { get; set; } = "contacts.json";

    public void Load()
    {
        if (_isLoaded) return;

        var json = File.ReadAllText(PathToJson);
        var contacts = JsonSerializer.Deserialize<IEnumerable<Registration>>(json);

        if (contacts == null) return;

        foreach (var contact in contacts)
        {
            _contacts.Add(contact);
        }

        _isLoaded = true;
    }

    public void Add(Registration registration)
    {
        _contacts.Add(registration);

        SaveChanges();
    }

    public IEnumerable<Registration> GetAll()
    { return _contacts; }

    public void Password(string password)
    {
        _isLoaded = true; SaveChanges();
    }
    public void RegistrationDate(DateTime date)
    {
        _isLoaded = true; SaveChanges();

    }
    public void Login()
    {
        _isLoaded = true; SaveChanges();
    }
    public void Update(Registration registration)
    {
        var existing = GetById(registration.Id); 

        if (existing != null)  
        {
            existing.FirstName = registration.FirstName;
            existing.LastName = registration.LastName;
            existing.Email = registration.Email;
            existing.Password = registration.Password;
            existing.Login = registration.Login;
            existing.Score = registration.Score;

            SaveChanges();  
        }
    }
    public Registration? GetById(Guid id)
    {
       var contact = _contacts.FirstOrDefault(x => x.Id == id); //ищет человека по его уникальному номеру (как паспорт или ИНН).
       return contact;
    }

    public void Delete(Guid id)
    {
        var contact = SearchContact(id);
        _contacts.Remove(contact);

        SaveChanges();
    }

    private Registration SearchContact(Guid id)
    {
        var contact = _contacts.SingleOrDefault(c => c.Id == id);
        return contact ?? throw new ArgumentOutOfRangeException($"{id} not found"); //
    }

    public void SaveChanges()
    {
        var json = JsonSerializer.Serialize(_contacts);
        File.WriteAllText(PathToJson, json);
    }
}
