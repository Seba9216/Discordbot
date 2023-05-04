using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discordbot.DomainModel.GameDomainModel
{
    public class Style
    {
        public string description { get; set; }
        public List<Selection> selections { get; set; }
        public int style { get; set; }
    }
}
