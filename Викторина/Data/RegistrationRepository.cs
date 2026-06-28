using System;
using System.Collections.Generic;
using System.Linq;
using Викторина.Interfaces;
using Викторина.Models;

namespace Викторина.Data
{
    //Отвечает за ОБСЛУЖИВАНИЕ читателей
    public class RegistrationRepository : ICrud
    {
        private readonly JsonContext _context;
        public RegistrationRepository()
        {
            _context = new JsonContext("contacts.json");
        }
        public void Add(Registration registration)
        {
            _context.Add(registration);
        }
        public IEnumerable<Registration> GetAll()
        {
            return _context.GetAll();
        }
        public void Password(string password)
        {
            _context.Password(password);
        }
        public void RegistrationDate(DateTime date)
        {
            _context.RegistrationDate(date);
        }
        public void Login()
        {
            _context.Login();
        }
        public void Update(Registration registration)
        {
            _context.Update(registration);
        }

        public Registration? GetById(Guid id) 
        {
           return _context.GetById(id);
        }
        public void Delete(Guid id)
        {
             _context.Delete(id);
        }
        public void Load()
        {
            _context.Load();

        }
        public void SaveChanges()
        { 
            _context.SaveChanges(); 
        }
    }
}

