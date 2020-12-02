using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GameSite.Data.Entities
{
    public class ConsoleUnit
    {
        [Key]

        public int ConsoleId { get; set; }
        public string ConsoleName { get; set; }
        public string Description { get; set; }
        public bool IsItOnPc { get; set; }
        public List<Game> Games { get; set; }
    }
}
