using Wicket.Models;
using Wicket.ViewModels;
using Wicket.Helpers;
using System.Collections.ObjectModel;
using System.Linq;

namespace Wicket.ViewModels
{
    public class MatchViewModel
    {
        public Match ActiveMatch { get; set; }
        public Scorecard.RootObject MatchScorecard {get;set;}

        public MatchViewModel(Match match)
        {
            ActiveMatch = match;
            MatchScorecard = WicketHelper.GetScorecard(match);
        }
    }
}