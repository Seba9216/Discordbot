using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discordbot.DomainModel.GameDomainModel
{
    public class GamePerks
    {
        public StatPerks statPerks { get; set; }
        public List<Style> styles { get; set; }
    }
}
