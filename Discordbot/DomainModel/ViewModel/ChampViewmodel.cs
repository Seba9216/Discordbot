using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discordbot.DomainModel.ViewModel
{
    public class ChampViewmodel
    {
        public string Champname { get; set; }
        public decimal Winrate { get; set;}
        public decimal KDA { get; set;}
        public int Amount_Of_Games { get; set;}

    }
}
