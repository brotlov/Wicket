using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Wicket.Models;
using System.Linq;
using Xamarin.Forms;
using Newtonsoft.Json;


namespace Wicket.Helpers
{
    public static class WicketHelper
	{
		public static ObservableCollection<DateItem> Dates { get; set; }

        public static ObservableCollection<Match> ActiveMatch {get;set;}

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

        public static ObservableCollection<Match> GetMatchList(DateTime Date)
        {
            System.Net.WebClient wc = new System.Net.WebClient();
            var rawData = wc.DownloadString("http://cricapi.com/api/matches?apikey=azrUF5YaYJhNeXAlzRoqJnA3wZB2");
            var data = JsonConvert.DeserializeObject<RootObject>(rawData);
            var MatchList = new ObservableCollection<Match>(data.matches.Where(x => x.date == Date));
            return MatchList;
        }

        static WicketHelper()
        {
            ActiveMatch = new ObservableCollection<Match>();
            //ActiveMatch.Add(new Match
            //{ 
            //    Team1 = "Australia", 
            //    Team2 = "England", 
            //    MatchType="Test Match" 
            //});
            Dates = new ObservableCollection<DateItem>();
            Dates.Add(new DateItem{ 
                Date = DateTime.Today,
                Text = ConvertDate(DateTime.Today),
                MatchList = new ObservableCollection<Match>(GetMatchList(DateTime.Today)),
                Visible = GetMatchList(DateTime.Today).Count() > 0 ? true : false,
                ErrorShown = GetMatchList(DateTime.Today).Count() > 0 ? false : true,
            });
        }
	}
}