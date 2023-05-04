using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discordbot.DomainModel.GameDomainModel
{
    public class Objectives
    {
        public Baron baron { get; set; }
        public Champion champion { get; set; }
        public Dragon dragon { get; set; }
        public Inhibitor inhibitor { get; set; }
        public RiftHerald riftHerald { get; set; }
        public Tower tower { get; set; }
    }
}
