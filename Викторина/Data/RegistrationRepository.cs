using System;
using System.Collections.Generic;
using System.Linq;
using Викторина.Interfaces;
using Викторина.Models;

namespace Викторина.Data
{
    public class RegistrationRepository : ICrud
    {
        private readonly JsonContext _context;
        public RegistrationRepository()
        {
            _context = new JsonContext("contacts.json");
        }
        public void Add(User user)
        {
            _context.Contacts.Add(user);
        }
        public IEnumerable<User> GetAll()
        {
            return _context.Contacts; ;
        }

        public void Update(User user)
        {
            var existing = GetById(user.Id);
            if (existing != null)
            {
                existing.FirstName = user.FirstName;
                existing.LastName = user.LastName;
                existing.Email = user.Email;
                existing.Password = user.Password;
                existing.Login = user.Login;
                existing.Score = user.Score;
                _context.SaveChanges();
            }
        }

        public User? GetById(Guid id)
        {
            return _context.Contacts.FirstOrDefault(x => x.Id == id);
        }
        public void Delete(Guid id)
        {
            var contact = GetById(id);
            if (contact != null)
            {
                _context.Contacts.Remove(contact);
                _context.SaveChanges();
            }
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}

