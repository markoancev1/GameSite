using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameSite.Models
{
    public class GameEditViewModel : GameViewModel
    {
            public int Id { get; set; }
            public string ExistingPhotoPath { get; set; }
    }
}
