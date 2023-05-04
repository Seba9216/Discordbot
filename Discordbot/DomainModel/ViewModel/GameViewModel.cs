using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Discordbot.DomainModel.ViewModel
{
  public enum Result
    {
        Win,Loss
    }
    public class GameViewModel
    {
        public int Duration_Mins { get; set; }
        
        public Result result;
        
        public int kills { get; set; }
        
        public int deaths { get; set; }
        
        public double KDA { get; set; }
        
        public int KillPartionPercentage { get; set; }
        
        public double CS { get; set; }
        
        public double CS_Min { get; set; }

        ChampViewmodel ChampViewmodel { get; set;}


    }
}
