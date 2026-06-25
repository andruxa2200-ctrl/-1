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
            _context = new JsonContext();
            Load();
        }

        public void Add(Registration registration)
        {
            _context.Registrations.Add(registration);
            Save();
        }
        public IEnumerable<Registration> GetAll()
        {
            return _context.Registrations;
        }
        public void Update(Registration registration)
        {
            _context.Registrations.Update(registration);
        }
        public void Delete(Guid id)
        {
            _context.Registrations.Remove(id);
        }
        public void Load()
        {
            _context.Load();

        }
    }
}

