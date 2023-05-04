﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discordbot.DomainModel.ViewModel
{
    public class PlayerViewModel
    {
        public double KDA { get; set; }
        public string sumonername { get; set; }
        public int SummonerID { get; set; }
        public double Winrate { get; set; }
        public int wins { get; set; }
        public int losses { get; set; }
        public List<GameViewModel> Games { get; set; }


    }
}
