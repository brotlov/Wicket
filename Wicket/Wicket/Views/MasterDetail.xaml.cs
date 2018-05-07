using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Wicket.Helpers;
using Wicket.Models;
using Wicket.ViewModels;

namespace Wicket
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetail : ContentPage
    {
        private ObservableCollection<DateItem> DateList { get; set; }
        public MasterDetail()
        {
            var dataView = new DateViewModel();
            BindingContext = dataView;
            InitializeComponent();
            DateList = dataView.Dates;
            dataView.Loading = false;

            var previousLabelTap = new TapGestureRecognizer();
            previousLabelTap.Tapped += (s, e) =>
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
                        Visible = WicketHelper.GetMatchList(DateList[index].Date.AddDays(-1)).Count() > 0 ? true : false,
                        ErrorShown = WicketHelper.GetMatchList(DateList[index].Date.AddDays(-1)).Count() > 0 ? false : true,
                    });
                    DateListCarousel.Position = 0;
                }
                else
                {
                    index = DateListCarousel.Position - 1;
                    DateListCarousel.Position = DateListCarousel.Position - 1;
                }

            };
            PreviousLabel.GestureRecognizers.Add(previousLabelTap);

            var nextLabelTap = new TapGestureRecognizer();
            nextLabelTap.Tapped += (s, e) =>
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
                        Visible = WicketHelper.GetMatchList(DateList[index].Date.AddDays(-1)).Count() > 0 ? true : false,
                        ErrorShown = WicketHelper.GetMatchList(DateList[index].Date.AddDays(-1)).Count() > 0 ? false : true,
                    });
                    DateListCarousel.Position = index + 1;
                }
                else
                {
                    index = DateListCarousel.Position + 1;
                    DateListCarousel.Position = DateListCarousel.Position + 1;
                }
                DateLabel.Text = WicketHelper.ConvertDate(DateList[index].Date);

            };
            NextLabel.GestureRecognizers.Add(nextLabelTap);
        }

        private async void itemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedItem = e.SelectedItem as Match;
            await Navigation.PushAsync(new Views.MatchInformation(selectedItem) { Title = selectedItem.Team1 + " v " + selectedItem.Team2}, true);
        }

        private void carouselOnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var position = DateListCarousel.Position;
            var game = DateListCarousel.Item as DateItem;
            if (game == null)
                return;
            DateLabel.Text = WicketHelper.ConvertDate(game.Date);
        }
    }
}