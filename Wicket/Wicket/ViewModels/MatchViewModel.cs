using Wicket.Models;
using Wicket.ViewModels;
using Wicket.Helpers;
using System.Collections.ObjectModel;
using System.Linq;

namespace Wicket.ViewModels
{
    public class MatchViewModel
    {
        public ObservableCollection<Match> ActiveMatch { get; set; }

        public MatchViewModel()
        {
            ActiveMatch = WicketHelper.ActiveMatch;
        }
    }
}