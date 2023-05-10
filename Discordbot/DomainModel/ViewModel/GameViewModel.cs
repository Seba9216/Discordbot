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
        public decimal Duration_Mins { get; set; }

        public Result result;
        public int kills { get; set; }
        public int deaths { get; set; }
        public decimal KDA { get; set; }
        public int assist { get; set; }
        public int KillPartionPercentage { get; set; }
        public double CS { get; set; }
        public decimal CS_Min { get; set; }

    }
}
