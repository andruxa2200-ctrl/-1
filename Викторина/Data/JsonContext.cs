using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Викторина.Models;
using Викторина.Interfaces;

namespace Викторина.Data;

//Отвечает за ХРАНЕНИЕ книг(данных) и работу с файлами
public class JsonContext 
{   
    public JsonContext(string pathToJson)
    {
        PathToJson = pathToJson;
        Load();
        
    }
    public JsonContext()
    {
        PathToJson = "contacts.json"; 
        Load();
    }
    private  List<User> _contacts = [];
    private bool _isLoaded = false;
    public string PathToJson { get; set; } = "contacts.json";

    public List<User> Contacts => _contacts;

    public void Load()
    {
        if (_isLoaded) return;

        if (!File.Exists(PathToJson) || new FileInfo(PathToJson).Length == 0)
        {
            File.WriteAllText(PathToJson, "[]");
            _isLoaded = true;
            return;
        }

        try
        {
            var json = File.ReadAllText(PathToJson);
            var contacts = JsonSerializer.Deserialize<List<User>>(json);
            if (contacts != null) _contacts = contacts;
        }
        catch
        {
            _contacts = [];
        }

        _isLoaded = true;
    }
    public void SaveChanges()
    {
        var json = JsonSerializer.Serialize(_contacts, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(PathToJson, json);
    }
}
