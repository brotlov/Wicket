using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Wicket.Models;
using System.Linq;
using Xamarin.Forms;

namespace Wicket.Helpers
{
    public static class WicketHelper
	{
		public static ObservableCollection<DateItem> Dates { get; set; }

        public static string ConvertDate(DateTime Date)
        {
            var returnString = "";
            returnString = Date.ToString("dd/MM/yyyy");
            if (Date == DateTime.Today.Date)
            {
                returnString = "Today";
            }
            else if (Date.AddDays(1) == DateTime.Today.Date)
            {
                returnString = "Yesterday";
            }
            else if (Date == DateTime.Today.AddDays(1))
            {
                returnString = "Tomorrow";
            }
            return returnString;
        }

        static WicketHelper()
        {
            Dates = new ObservableCollection<DateItem>();
            Dates.Add(new DateItem{ 
                Date = DateTime.Today,
                Text = ConvertDate(DateTime.Today),
                MatchList = new ObservableCollection<Match> { new Match { Team1 = "Australia", Team2 = "England" }, new Match { Team1 = "Australia", Team2 = "England" }, new Match { Team1 = "Australia", Team2 = "England" } }
            });
            Dates.Add(new DateItem{ 
                Date = DateTime.Today.AddDays(1),
                Text = ConvertDate(DateTime.Today.AddDays(1)),
                MatchList = new ObservableCollection<Match> { new Match { Team1 = "Australia", Team2 = "England" }, new Match { Team1 = "Australia", Team2 = "England" }, new Match { Team1 = "Australia", Team2 = "England" } }
            });
            Dates.Add(new DateItem{ 
                Date = DateTime.Today.AddDays(2),
                Text = ConvertDate(DateTime.Today.AddDays(2)),
                MatchList = new ObservableCollection<Match> { new Match { Team1 = "Australia", Team2 = "England" }, new Match { Team1 = "Australia", Team2 = "England" }, new Match { Team1 = "Australia", Team2 = "England" } }
            });
            Dates.Add(new DateItem{ 
                Date = DateTime.Today.AddDays(3),
                Text = ConvertDate(DateTime.Today.AddDays(3)),
                MatchList = new ObservableCollection<Match> { new Match { Team1 = "Australia", Team2 = "England" }, new Match { Team1 = "Australia", Team2 = "England" }, new Match { Team1 = "Australia", Team2 = "England" } }
            });
            Dates.Add(new DateItem{ 
                Date = DateTime.Today.AddDays(4),
                Text = ConvertDate(DateTime.Today.AddDays(4)),
                MatchList = new ObservableCollection<Match> { new Match { Team1 = "Australia", Team2 = "England" }, new Match { Team1 = "Australia", Team2 = "England" }, new Match { Team1 = "Australia", Team2 = "England" } }
            });
            Dates.Add(new DateItem{ 
                Date = DateTime.Today.AddDays(5),
                Text = ConvertDate(DateTime.Today.AddDays(5)),
                MatchList = new ObservableCollection<Match> { new Match { Team1 = "Australia", Team2 = "England" }, new Match { Team1 = "Australia", Team2 = "England" }, new Match { Team1 = "Australia", Team2 = "England" } }
            });
            Dates.Add(new DateItem{ 
                Date = DateTime.Today.AddDays(6),
                Text = ConvertDate(DateTime.Today.AddDays(6)),
                MatchList = new ObservableCollection<Match> { new Match { Team1 = "Australia", Team2 = "England" }, new Match { Team1 = "Australia", Team2 = "England" }, new Match { Team1 = "Australia", Team2 = "England" } }
            });
            Dates.Add(new DateItem{ 
                Date = DateTime.Today.AddDays(7),
                Text = ConvertDate(DateTime.Today.AddDays(7)),
                MatchList = new ObservableCollection<Match> { new Match { Team1 = "Australia", Team2 = "England" }, new Match { Team1 = "Australia", Team2 = "England" }, new Match { Team1 = "Australia", Team2 = "England" } }
            });
        }
	}
}