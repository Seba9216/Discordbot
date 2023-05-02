using Discord.Commands;
using Discordbot.RiotAPI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Discordbot
{
    public class Infomodule : ModuleBase<SocketCommandContext>
    {

        private APICalls Api = new APICalls();
        [Command("Test")]
        public Task DinMorErDød([Remainder] string echo) => ReplyAsync("Din mor er død philip");

        [Command("GetQ")]
        public async Task FindUser([Remainder] string Username)
        {
          var summonerid =  Api.GetuserPUUIDs(Username)
                .Result.Split(',')
                .Where(x => x.Contains("id"))
                .FirstOrDefault().Split(':')[1]
                .Replace('"',' ').Trim();

            var users = Api.GetGameSummIDs(summonerid).Result;
            List<string> Puuid = new List<string>(); 
            foreach(var user in users.participants)
            {
                Puuid.Add(Api.GetuserPUUIDs(user.summonerName).Result.Split(',').Where(x => x.Contains("puuid")).FirstOrDefault().Split(':')[1].Replace('"', ' ').Trim());


            }
            Hashtable Puuid_MatchID = new Hashtable(); 

            foreach(var id in Puuid)
            {
                if (!Puuid_MatchID.ContainsKey(id))
                {
                    Puuid_MatchID.Add(id, Api.GetGameIDs(id).Result);
                }
            }
            List<string[]> nemt = new List<string[]>();
            foreach (var matchid in Puuid_MatchID.Values)
            {
                string matches = matchid.ToString();
                var splitted = matches.Replace('"', '*');
                splitted = splitted.Replace("*", "");
                splitted = splitted.Replace("[", "");
                splitted = splitted.Replace("]", "");
                var matchids  = splitted.Split(',');


            }


            string gg = ""; 
        }
    }
}
