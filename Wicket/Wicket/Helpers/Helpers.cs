using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Wicket.Models;
using System.Linq;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Http;


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
            var baseUrl = "http://origin-apinew.cricket.com.au/matches?completedLimit=12&inProgressLimit=12&upcomingLimit=12";
            System.Net.WebClient wc = new System.Net.WebClient();
            var rawData = wc.DownloadString(baseUrl + "&format=json");
            var data = JsonConvert.DeserializeObject<RootObject>(rawData);
            var MatchList = new ObservableCollection<Match>(data.matchList.matches.Where(x => (x.startDateTime.Date == Date.Date) ||  (x.startDateTime.Date <= Date.Date && x.endDateTime.Date >= Date.Date)));
            return MatchList;
        }

        public static async Task<ObservableCollection<Match>> UpdateMatchListAsync(DateItem Date)
        {
            var baseUrl = "http://origin-apinew.cricket.com.au/matches?completedLimit=12&inProgressLimit=12&upcomingLimit=12";
            var client = new HttpClient();
            string response = await client.GetStringAsync(baseUrl + "&format=json");
            var data = JsonConvert.DeserializeObject<RootObject>(response.ToString());
            var MatchList = new ObservableCollection<Match>(data.matchList.matches.Where(x => (x.startDateTime.Date == Date.Date) ||  (x.startDateTime.Date <= Date.Date && x.endDateTime.Date >= Date.Date)));
            return MatchList;
        }

        public static async Task<Scorecard> GetScorecardAsync(Match matchItem)
        {
            var baseUrl = "http://origin-apinew.cricket.com.au/scorecards/full/" + matchItem.series.id + "/" + matchItem.id;
            var client = new HttpClient();
            string response = await client.GetStringAsync(baseUrl + "&format=json");
            var scoreCard = JsonConvert.DeserializeObject<Scorecard>(response.ToString());
            return scoreCard;
        }


        static WicketHelper()
        {
            ActiveMatch = new ObservableCollection<Match>();
            Dates = new ObservableCollection<DateItem>();
            Dates.Add(new DateItem{ 
                Date = DateTime.Today.AddDays(-1),
                Text = ConvertDate(DateTime.Today.AddDays(-1)),
                MatchList = new ObservableCollection<Match>(GetMatchList(DateTime.Today.AddDays(-1))),
                Loading = false
            });
            Dates.Add(new DateItem{ 
                Date = DateTime.Today,
                Text = ConvertDate(DateTime.Today),
                MatchList = new ObservableCollection<Match>(GetMatchList(DateTime.Today)),
                Loading = false
            });
            Dates.Add(new DateItem{ 
                Date = DateTime.Today.AddDays(1),
                Text = ConvertDate(DateTime.Today.AddDays(1)),
                MatchList = new ObservableCollection<Match>(GetMatchList(DateTime.Today.AddDays(1))),
                Loading = false
            });
        }
	}
}