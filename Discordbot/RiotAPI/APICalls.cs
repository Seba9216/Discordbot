﻿using Discordbot.DomainModel;
using Discordbot.DomainModel.GameDomainModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Discordbot.RiotAPI
{
    public class APICalls
    {

        public string API_KEY = ((string)JsonConvert.DeserializeObject<dynamic>(File.ReadAllText("../../../config.json"))["APIKEY"]).Replace("{","").Replace("}",""); 

        public async Task<string> GetuserPUUIDs(string Username)
        {
            HttpClient client = new HttpClient();
            
            if (Username.Contains(" ")) Username = Username.Replace(" ", "%20"); 
            string defualtgamestring = $"https://euw1.api.riotgames.com/lol/summoner/v4/summoners/by-name/{Username}?api_key=&APIKEY&";

            defualtgamestring = defualtgamestring.Replace("&APIKEY&", API_KEY); 
           
          var Request =  WebRequest.CreateHttp(defualtgamestring);

            var response = Request.GetResponseAsync();
            using (var  reader = new StreamReader(response.Result.GetResponseStream()))
            {
                string nemt =  reader.ReadToEnd();
                return nemt; 
            }
            
             
        }
        //returns all of the Summids
        //of the current game being played
        public async Task<Root> GetGameSummIDs(string Puuid)
        {
            HttpClient client = new HttpClient();
            string defualtgamestring = $"https://euw1.api.riotgames.com/lol/spectator/v4/active-games/by-summoner/{Puuid}?api_key=&APIKEY&";
            defualtgamestring = defualtgamestring.Replace("&APIKEY&", API_KEY); 
            var request = WebRequest.CreateHttp(defualtgamestring);

            var response =  request.GetResponseAsync();
            string nemt = ""; 
            using (var reader = new StreamReader(response.Result.GetResponseStream()))
            {
                nemt = reader.ReadToEnd();



            }
            Root res = JsonConvert.DeserializeObject<Root>(nemt);

            return res; 
        }
        //get game ids from Puuids
        public async Task<string> GetGameIDs(string puuid)
        {
            
            HttpClient client = new HttpClient();
            string defualtgamestring = $"https://europe.api.riotgames.com/lol/match/v5/matches/by-puuid/{puuid}/ids?start=0&count=5&api_key=&APIKEY&";
            defualtgamestring = defualtgamestring.Replace("&APIKEY&", API_KEY);
            var request = WebRequest.CreateHttp(defualtgamestring);

            var response = request.GetResponseAsync();
            string nemt = "";
            using (var reader = new StreamReader(response.Result.GetResponseStream()))
            {

                nemt = reader.ReadToEnd();
            }
            return nemt; 
        }

       public async Task<GameRoot> Getgames(string MatchID)
        {
            HttpClient client = new HttpClient();
            string defualtgamestring = $"https://europe.api.riotgames.com/lol/match/v5/matches/{MatchID}?api_key=&APIKEY&";
            defualtgamestring = defualtgamestring.Replace("&APIKEY&", API_KEY);
            var request = WebRequest.CreateHttp(defualtgamestring);

            var response = request.GetResponseAsync();
            string nemt = "";
            using (var reader = new StreamReader(response.Result.GetResponseStream()))
            {
                nemt = reader.ReadToEnd();
            }
            GameRoot res = JsonConvert.DeserializeObject<GameRoot>(nemt);
            return res; 
       }


    }
}
