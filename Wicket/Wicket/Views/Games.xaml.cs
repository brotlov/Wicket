using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;
using Wicket.Helpers;
using Wicket.Models;
using Wicket.ViewModels;

namespace Wicket
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Games : ContentPage
	{
        private ObservableCollection<DateItem> DateList { get; set; }
		public Games ()
		{
			InitializeComponent();
            var dataView = new DateViewModel();
            DateListCarousel.ItemsSource = dataView.Dates;
            DateListCarousel.Position = 1;
            BindingContext = dataView;
            DateList = dataView.Dates;

            ToolbarItems.Add(new ToolbarItem("Filter", "filter.png",() =>
            {
                //logic code goes here
            }));

            var previousLabelTap = new TapGestureRecognizer();
            previousLabelTap.Tapped += (s, e) =>
            {
                addPreviousSlide();

            };
            PreviousLabel.GestureRecognizers.Add(previousLabelTap);

            var nextLabelTap = new TapGestureRecognizer();
            nextLabelTap.Tapped += (s, e) =>
            {
                addNextSlide();

            };
            NextLabel.GestureRecognizers.Add(nextLabelTap);
        }

        private async void itemSelected(object sender, ItemTappedEventArgs e)
        {
            var selectedItem = e.Item as Match;
            await Navigation.PushAsync(new Views.MatchInformation(selectedItem) { Title = selectedItem.homeTeam.name + " v " + selectedItem.awayTeam.name}, true);
        }

        private void carouselOnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var position = DateListCarousel.Position;
            DateLabel.Text = WicketHelper.ConvertDate(DateList[position].Date);
            var game = DateList[position] as DateItem;
            if (game == null)
                return;
            addNewSlide();
        }

        private void addNewSlide()
        {
            var index = DateListCarousel.Position;
            if (index == DateList.Count() - 1)
            {
                DateList.Add(new DateItem
                {
                    Date = DateList[index].Date.AddDays(1),
                    Text = WicketHelper.ConvertDate(DateList[index].Date.AddDays(1)),
                    MatchList = WicketHelper.GetMatchList(DateList[index].Date.AddDays(1)),
                    Loading = false,
                });
            }
            else if (DateListCarousel.Position == 0)
            {
                DateList.Insert(0, new DateItem
                {
                    Date = DateList[index].Date.AddDays(-1),
                    Text = WicketHelper.ConvertDate(DateList[index].Date.AddDays(-1)),
                    MatchList = WicketHelper.GetMatchList(DateList[index].Date.AddDays(-1)),
                    Loading = false,
                });
            }

        }

        private void addNextSlide()
        {
            int index;
            if (DateListCarousel.Position == DateList.Count() - 1)
            {
                index = DateList.Count() - 1;
                DateList.Add(new DateItem
                {
                    Date = DateList[index].Date.AddDays(1),
                    Text = WicketHelper.ConvertDate(DateList[index].Date.AddDays(1)),
                    MatchList = WicketHelper.GetMatchList(DateList[index].Date.AddDays(1)),
                });
                DateListCarousel.Position = index + 1;
            }
            else
            {
                index = DateListCarousel.Position + 1;
                DateListCarousel.Position = DateListCarousel.Position + 1;
            }
            DateLabel.Text = WicketHelper.ConvertDate(DateList[index].Date);
        }

        private void addPreviousSlide()
        {
            int index;
            //Check if slide to the left already exists
            //If so, move back one spot. If not, add new data one less than the slide's date to the DateList
            if (DateListCarousel.Position == 0)
            {
                index = 0;
                DateList.Insert(0, new DateItem
                {
                    Date = DateList[index].Date.AddDays(-1),
                    Text = WicketHelper.ConvertDate(DateList[index].Date.AddDays(-1)),
                    MatchList = WicketHelper.GetMatchList(DateList[index].Date.AddDays(-1)),
                });
                DateListCarousel.Position = 0;
            }
            else
            {
                index = DateListCarousel.Position - 1;
                DateListCarousel.Position = DateListCarousel.Position - 1;
            }
        }

        async Task RefreshList(object sender, EventArgs e)
        {
            ListView lv = (ListView)sender;
            var index = DateListCarousel.Position;
            lv.ItemsSource = null;
            var matchCallResult = await WicketHelper.UpdateMatchListAsync(DateList[index]);
            lv.ItemsSource = matchCallResult;
            lv.IsRefreshing = false;
        }
    }
}