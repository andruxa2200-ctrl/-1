using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Викторина.Models;

namespace PhoneBookApp.DAL;

public class JsonContext : ICrud
{
    private readonly List<Registration> _contacts = [];
    private bool _isLoaded = false;
    public required string PathToJson { get; init; }

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

    public void Update(Registration registration)
    {
        var existing = GetById(registration.Id); 

        if (existing != null)  
        {
            existing.FirstName = registration.FirstName;
            existing.LastName = registration.LastName;
            existing.Email = registration.Email;
            existing.Password = registration.Password;
            existing.Score = registration.Score;

            SaveChanges();  
        }
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
        return contact ?? throw new ArgumentOutOfRangeException($"{id} not found");
    }

    private void SaveChanges()
    {
        var json = JsonSerializer.Serialize(_contacts);
        File.WriteAllText(PathToJson, json);
    }
}
