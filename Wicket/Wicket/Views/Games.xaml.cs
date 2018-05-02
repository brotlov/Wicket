using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;

namespace Wicket
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Games : ContentPage
	{
		public Games ()
		{
			InitializeComponent();
            DateTime[] last14Days = Enumerable.Range(0, 14).Select(i => DateTime.Now.Date.AddDays(-i)).ToArray();
            DateTime[] next14Days = Enumerable.Range(1, 14).Select(i => DateTime.Now.Date.AddDays(i)).ToArray();

            var dates = new List<DateObject>();
            var mainDateList = new List<DateObject>();
            foreach (var day in last14Days)
            {
                var newDate = new DateObject();
                newDate.Date = day;
                dates.Add(newDate);
            }
            foreach (var day in next14Days)
            {
                var newDate = new DateObject();
                newDate.Date = day;
                dates.Add(newDate);
            }
            foreach (var d in dates.OrderBy(x => x.Date))
            {
                d.Text = d.Date.ToString("dd/MM/yyyy");
                d.GameList= new List<GameObject> { new GameObject { Team1 = "Australia", Team2 = "India"}, new GameObject { Team1 = "England", Team2 = "Sri Lanka"}};
                mainDateList.Add(d);
            }

            var previousLabelTap = new TapGestureRecognizer();   
            previousLabelTap.Tapped += (s,e) =>
            {
                int index;
                if (GamesCarousel.Position == 0)
                {
                    GamesCarousel.Position = mainDateList.Count() - 1;
                    index = mainDateList.Count() - 1;
                }
                else
                {
                    index = GamesCarousel.Position - 1;
                    GamesCarousel.Position = GamesCarousel.Position - 1;
                }
                DateLabel.Text = ConvertDate(mainDateList[index].Date);
                
            };
            PreviousLabel.GestureRecognizers.Add(previousLabelTap);

            var nextLabelTap = new TapGestureRecognizer();   
            nextLabelTap.Tapped += (s,e) =>
            {
                int index;
                if (GamesCarousel.Position == dates.Count() - 1)
                {
                    GamesCarousel.Position = 0;
                    index = 0;
                }
                else
                {
                    index = GamesCarousel.Position + 1;
                    GamesCarousel.Position = GamesCarousel.Position + 1;
                }
                DateLabel.Text = ConvertDate(mainDateList[index].Date);
                
            };
            NextLabel.GestureRecognizers.Add(nextLabelTap);

            GamesCarousel.ItemsSource = mainDateList;
            GamesCarousel.Position = 13;
        }

        public string ConvertDate(DateTime Date)
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

        public class DateObject
        {
            public DateTime Date {get;set;}
            public string Text {get;set;}
            public List<GameObject> GameList {get;set;}
        }

        public class GameObject
        {
            public string Date {get;set;}
            public string Team1 {get;set;}
            public string Team2 {get;set;}
        }

        private void carouselOnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var position = GamesCarousel.Position;
            var game = GamesCarousel.Item as DateObject;
              if (game == null)
                return;
 
              DateLabel.Text = ConvertDate(game.Date);
        }
	}
}