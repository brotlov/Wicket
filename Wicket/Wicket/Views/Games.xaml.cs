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
			var dataView = new DateViewModel();
            BindingContext = dataView;
            InitializeComponent();
            DateList = dataView.Dates;

            var previousLabelTap = new TapGestureRecognizer();
            previousLabelTap.Tapped += (s, e) =>
            {
                int index;
                if (DateListCarousel.Position == 0)
                {
                    DateListCarousel.Position = DateList.Count() - 1;
                    index = DateList.Count() - 1;
                }
                else
                {
                    index = DateListCarousel.Position - 1;
                    DateListCarousel.Position = DateListCarousel.Position - 1;
                }
                DateLabel.Text = WicketHelper.ConvertDate(DateList[index].Date);

            };
            PreviousLabel.GestureRecognizers.Add(previousLabelTap);
            var nextLabelTap = new TapGestureRecognizer();
            nextLabelTap.Tapped += (s, e) =>
            {
                int index;
                if (DateListCarousel.Position == DateList.Count() - 1)
                {
                    DateListCarousel.Position = 0;
                    index = 0;
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