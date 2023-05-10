using Discord;
using Discord.Commands;
using Discordbot.DomainModel;
using Discordbot.DomainModel.GameDomainModel;
using Discordbot.DomainModel.ViewModel;
using Discordbot.RiotAPI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            var summonerid = Api.GetuserPUUIDs(Username)
                  .Result.Split(',')
                  .Where(x => x.Contains("id"))
                  .FirstOrDefault().Split(':')[1]
                  .Replace('"', ' ').Trim();

            var users = Api.GetGameSummIDs(summonerid).Result;
            List<string> Puuid = new List<string>();
            foreach (var user in users.participants)
            {
                Puuid.Add(Api.GetuserPUUIDs(user.summonerName).Result.Split(',').Where(x => x.Contains("puuid")).FirstOrDefault().Split(':')[1].Replace('"', ' ').Trim());


            }
            Dictionary<string, string[]> Puuid_MatchID = new Dictionary<string, string[]>();

            foreach (var id in Puuid)
            {
                if (!Puuid_MatchID.ContainsKey(id))
                {
                    Puuid_MatchID.Add(id, Api.GetGameIDs(id).Result.Replace('"', '*').Replace("[", "").Replace("]", "").Replace("*", "").Split(','));
                }
            }
            int keyfinder = 0;
            string[] keys = new string[Puuid_MatchID.Keys.Count];
            List<PlayerViewModel> Data = new List<PlayerViewModel>();
            foreach (string[] matchid in Puuid_MatchID.Values)
            {
                //the player's ID
                string playerPuuid = Puuid_MatchID.ElementAt(keyfinder).Key;
                List<GameRoot> gameroots = new List<GameRoot>();

                // we look at the 20 latest matches of the player 
                foreach (var match in matchid)
                {
                    var temp = Api.Getgames(match).Result;
                    gameroots.Add(temp);
                }
                // all of the teams who won the match 
                var teamswhowon = gameroots.Where(x =>
                {
                    for (int i = x.info.teams.Count - 1; i >= 0; i--)
                    {
                        if (!x.info.teams[i].win)
                        {
                            x.info.teams.RemoveAt(i);
                        }
                    }
                    return true;
                });
                int j = -1;
                Dictionary<int, int> gameidandpos = new Dictionary<int, int>();

                //given player's TeamID's 
                var PlayerTeamIDs = gameroots.SelectMany(x => x.info.participants.Where(y => y.puuid == playerPuuid).Select(f => f.teamId)).ToList();

                var Whowon = gameroots.SelectMany(x => x.info.teams.Where(f => f.win).Select(g => g.teamId)).ToList();

                var diff = Whowon.Where(x =>
                {
                    j++;
                    if (x != PlayerTeamIDs[j])
                    {
                        gameidandpos.Add(j, PlayerTeamIDs[j]);
                    }
                    return x != PlayerTeamIDs[j];
                }).ToList();
                if (diff != null)
                {
                    string hej = "";
                    PlayerViewModel view = new PlayerViewModel();
                    ChampViewmodel champ = new ChampViewmodel();
                    GameViewModel game = new GameViewModel();
                    view.wins = 20 - gameidandpos.Count;
                    view.losses = gameidandpos.Count;
                    view.Winrate = (decimal)gameidandpos.Count / 20;
                    var name = gameroots.Select(x => x.info.participants.Where(y => y.puuid == playerPuuid).Select(h => h.summonerName)).FirstOrDefault();
                    view.sumonername = name.ElementAt(0);
                    var killsforgivenplayerin20games = gameroots.SelectMany(x => x.info.participants.Where(y => y.puuid == playerPuuid)).ToList();
                    int kills = killsforgivenplayerin20games.Select(x => x.kills).ToList().Sum();
                    int deaths = killsforgivenplayerin20games.Select(x => x.deaths).ToList().Sum();
                    int assits = killsforgivenplayerin20games.Select(x => x.assists).ToList().Sum();

                    decimal KDA = (decimal)(kills + assits) / deaths;
                    view.KDA = KDA;
                    var Champsplayed = killsforgivenplayerin20games.Select(x => x.championName).ToList().Distinct();

                    //stats of the diffrent champions of the player 
                    foreach (string tempchamp in Champsplayed)
                    {
                        champ = new ChampViewmodel();
                        var killsforchamp = killsforgivenplayerin20games.Where(x => x.championName == tempchamp).Select(V => V.kills).ToList();
                        var deathforchamp = killsforgivenplayerin20games.Where(x => x.championName == tempchamp).Select(V => V.deaths);
                        var champassits = killsforgivenplayerin20games.Where(x => x.championName == tempchamp).Select(V => V.assists).ToList();
                        decimal KDAforchamp = (decimal)(killsforchamp.Sum() + champassits.Sum()) / champassits.Sum();
                        champ.Champname = tempchamp;
                        champ.KDA = KDAforchamp;
                        champ.Amount_Of_Games = killsforchamp.Count();
                        decimal winrateforchamp = (decimal)gameroots
                          .SelectMany(x => x.info.participants.Where(c => c.championName == tempchamp && c.summonerName == name.ElementAt(0) && c.puuid == playerPuuid && c.win)).ToList().Count / (decimal)champ.Amount_Of_Games;
                        champ.Winrate = winrateforchamp * 100;
                        view.champs.Add(champ);

                    }
                    Data.Add(view); 
                }
                
                keyfinder++;
            }
            foreach(var views in Data)

            {
                var embed = new EmbedBuilder
                {
                    // Embed property can be set within object initializer
                    Title = "Hello world!",
                    Description = "I am a description set by initializer."
                };

                embed.AddField("Last 20 Games", "\u200b")
                .WithAuthor(Context.Client.CurrentUser)
                .WithColor(Color.Blue)
                .WithTitle("SummonerName")
                .WithDescription(views.sumonername)
                .WithUrl("")
                .WithCurrentTimestamp();
                await ReplyAsync(embed: embed.Build());
            }
        }
    }
}
