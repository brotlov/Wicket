using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Wicket.Models
{
    public class Match
    {
        public int unique_id { get; set; }
        
        [JsonProperty("team-2")]
        public string Team2 { get; set; }

        [JsonProperty("team-1")]
        public string Team1 { get; set; }

        public string type { get; set; }
        public DateTime date { get; set; }
        public DateTime dateTimeGMT { get; set; }
        public bool squad { get; set; }
        public string toss_winner_team { get; set; }
        public string winner_team { get; set; }
        public bool matchStarted { get; set; }
    }

    public class Provider
    {
        public string source { get; set; }
        public string url { get; set; }
        public DateTime pubDate { get; set; }
    }

    public class RootObject
    {
        public List<Match> matches { get; set; }
        public string v { get; set; }
        public int ttl { get; set; }
        public Provider provider { get; set; }
        public int creditsLeft { get; set; }
    }
}