﻿using Discord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discordbot.DomainModel.GameDomainModel
{

    public class Info
    {
        public long gameCreation { get; set; }
        public int gameDuration { get; set; }
        public long gameEndTimestamp { get; set; }
        public long gameId { get; set; }
        public string gameMode { get; set; }
        public string gameName { get; set; }
        public long gameStartTimestamp { get; set; }
        public string gameType { get; set; }
        public string gameVersion { get; set; }
        public int mapId { get; set; }
        public List<GameParticipant> participants { get; set; }
        public string platformId { get; set; }
        public int queueId { get; set; }
        public List<Team> teams { get; set; }
        public string tournamentCode { get; set; }
    }
}
