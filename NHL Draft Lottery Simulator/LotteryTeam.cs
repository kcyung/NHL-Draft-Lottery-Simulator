using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Net;
using System.IO;

namespace NHL_Draft_Lottery_Simulator
{
    public class LotteryTeam
    {
        public string TeamName;
        public int LotteryPlacement;
        public int NumCombos;
        public List<int> Entries;
        public Image Logo;
        
        // Constructor
        public LotteryTeam(string name, int place, int odds)
        {
            TeamName = name;
            LotteryPlacement = place;
            NumCombos = odds;
            Entries = new List<int>();
            try
            {
                Logo = Image.FromFile("../NHL Logos/" + TeamName + ".gif");
            }
            catch
            {
                Console.WriteLine("Can't Load Image" + TeamName);
                WebRequest req = WebRequest.Create("http://content.sportslogos.net/leagues/thumbs/1.gif");
                Stream stream = req.GetResponse().GetResponseStream();
                Image img = Image.FromStream(stream);
            }
        }

        public override string ToString()
        {
            string output = "";
            Entries.ForEach(o => output += o + " ");
            return base.ToString();
        }

    }
}
