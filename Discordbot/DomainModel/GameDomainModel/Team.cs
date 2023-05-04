using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discordbot.DomainModel.GameDomainModel
{
    public class Team
    {
        public List<Ban> bans { get; set; }
        public Objectives objectives { get; set; }
        public int teamId { get; set; }
        public bool win { get; set; }
    }
}
