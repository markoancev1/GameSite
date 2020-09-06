using GameSite.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameSite.Repository.Interface
{
    public interface IConsoleRepository
    {
        IEnumerable<ConsoleUnit> GetAllConsoles();

        void Add(ConsoleUnit console);
        void Edit(ConsoleUnit console);
        void Delete(int ConsoleID);
        ConsoleUnit GetConsoleById(int id);
    }
}
