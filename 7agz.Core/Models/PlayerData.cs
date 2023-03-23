using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7agz.Core.Models
{
    public class PlayerData
    {
        public int Id { get; set; }
        public decimal Rank { get; set; } = 0m;
        public decimal pace { get; set; } = 67.7008989m;
        public decimal defending { get; set; } = 51.55350326m;
        public decimal passing { get; set; } = 57.23377663m;
        public decimal shooting { get; set; } = 52.2983007m;
        public decimal dribbling { get; set; } = 62.53158478m;
        public int player_possition { get; set; } = -1;
        public decimal gk_handling { get; set; } = 63.14636542m;
        public decimal gk_kicking { get; set; } = 61.83251473m;
        public decimal gk_reflexes { get; set; } = 66.39047151m;
        public decimal gk_speed { get; set; } = 37.79862475m;
        public decimal gk_diving { get; set; } = 65.42239686m;
        public decimal gk_positioning { get; set; } = 63.37475442m;

        public int NumberOfMatches { get; set; } = 0;
        public int PlayerId { get; set; }
        //public Player Player { get; set; }

    }
}
