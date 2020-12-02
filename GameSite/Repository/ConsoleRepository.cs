using GameSite.Data;
using GameSite.Data.Entities;
using GameSite.Repository.Interface;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace GameSite.Repository
{
    public class ConsoleRepository : IConsoleRepository
    {
        private readonly DataContext _context;

        public ConsoleRepository(DataContext context)
        {
            _context = context;
        }

        public void Add(ConsoleUnit console)
        {
            _context.Consoles.Add(console);
            _context.SaveChanges();
        }

        public void Delete(int ConsoleID)
        {
            ConsoleUnit console = GetConsoleById(ConsoleID);
            _context.Consoles.Remove(console);
            _context.SaveChanges();
        }

        public void Edit(ConsoleUnit console)
        {
            _context.Consoles.Update(console);
            _context.SaveChanges();
        }

        public IEnumerable<ConsoleUnit> GetAllConsoles()
        {
            var result = _context.Consoles.AsEnumerable();
            return result;
        }

        public ConsoleUnit GetConsoleById(int id)
        {
            var result = _context.Consoles.FirstOrDefault(x => x.ConsoleId == id);
            return result;
        }

        public ConsoleUnit IsTheGameOnPC()
        {
            var result = _context.Consoles.Where(x => x.IsItOnPc == true).FirstOrDefault();
            return result;
        }
    }
}
