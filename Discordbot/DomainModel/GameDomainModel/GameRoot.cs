using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discordbot.DomainModel.GameDomainModel
{
    public class GameRoot
    {
        public MetaData metadata { get; set; }
        public Info info { get; set; }
    }
}
