using System;
using System.Collections.Generic;
using System.Text;

namespace Wicket.Models
{
    public class Scorecard
    {
        public class Series
        {
            public int id { get; set; }
            public string name { get; set; }
            public bool isDrinksNotificationEnabled { get; set; }
        }

        public class Meta
        {
            public int matchTypeId { get; set; }
            public Series series { get; set; }
        }

        public class Team
        {
            public int id { get; set; }
            public string shortName { get; set; }
        }

        public class Batsman
        {
            public int id { get; set; }
            public string name { get; set; }
            public string runs { get; set; }
            public string balls { get; set; }
            public string strikeRate { get; set; }
            public string fours { get; set; }
            public string sixes { get; set; }
            public string howOut { get; set; }
            public string fallOfWicket { get; set; }
            public string fallOfWicketOver { get; set; }
            public int fowOrder { get; set; }
            public string imageURL { get; set; }
        }

        public class Bowler
        {
            public int id { get; set; }
            public string name { get; set; }
            public string runsConceded { get; set; }
            public string maidens { get; set; }
            public string wickets { get; set; }
            public string overs { get; set; }
            public string wides { get; set; }
            public string noBalls { get; set; }
            public string economy { get; set; }
            public string imageURL { get; set; }
        }

        public class Innings
        {
            public int id { get; set; }
            public bool isDeclared { get; set; }
            public string name { get; set; }
            public string shortName { get; set; }
            public Team team { get; set; }
            public List<Batsman> batsmen { get; set; }
            public List<Bowler> bowlers { get; set; }
            public string wicket { get; set; }
            public string run { get; set; }
            public string over { get; set; }
            public string extra { get; set; }
            public string bye { get; set; }
            public string legBye { get; set; }
            public string wide { get; set; }
            public string noBall { get; set; }
            public string runRate { get; set; }
            public string requiredRunRate { get; set; }
        }

        public class FullScorecard
        {
            public List<Innings> innings { get; set; }
        }

        public class MostRunsAward
        {
            public int id { get; set; }
            public string name { get; set; }
            public string runs { get; set; }
            public string balls { get; set; }
            public string strikeRate { get; set; }
            public int fowOrder { get; set; }
        }

        public class MostWicketsAward
        {
            public int id { get; set; }
            public string name { get; set; }
            public string runsConceded { get; set; }
            public string wickets { get; set; }
            public string overs { get; set; }
            public string economy { get; set; }
        }

        public class MostRunsAwardPlayerResult
        {
            public int id { get; set; }
            public string name { get; set; }
            public string runs { get; set; }
            public string balls { get; set; }
            public string strikeRate { get; set; }
            public string fours { get; set; }
            public string sixes { get; set; }
            public string howOut { get; set; }
            public string fallOfWicket { get; set; }
            public string fallOfWicketOver { get; set; }
            public int fowOrder { get; set; }
        }

        public class MostWicketsAwardPlayerResult
        {
            public int id { get; set; }
            public string name { get; set; }
            public string runsConceded { get; set; }
            public string maidens { get; set; }
            public string wickets { get; set; }
            public string overs { get; set; }
            public string wides { get; set; }
            public string noBalls { get; set; }
            public string economy { get; set; }
        }

        public class FullScorecardAwards
        {
            public MostRunsAward mostRunsAward { get; set; }
            public MostWicketsAward mostWicketsAward { get; set; }
            public int manOfTheMatchId { get; set; }
            public List<object> manOfMatchBattingResults { get; set; }
            public List<object> manOfMatchBowlngResults { get; set; }
            public List<MostRunsAwardPlayerResult> mostRunsAwardPlayerResults { get; set; }
            public List<MostWicketsAwardPlayerResult> mostWicketsAwardPlayerResults { get; set; }
        }

        public class RootObject
        {
            public Meta meta { get; set; }
            public FullScorecard fullScorecard { get; set; }
            public FullScorecardAwards fullScorecardAwards { get; set; }
        }
    }
}
