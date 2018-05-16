using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Wicket.Models;
using Wicket.ViewModels;
using Wicket.Helpers;

namespace Wicket.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MatchInformation : TabbedPage
    {
        public MatchInformation (Match selectedMatch)
        {
            InitializeComponent();
            var dataView = new MatchViewModel(selectedMatch);
            BindingContext = dataView;
            ShowHomeTeam();
        }

        private void ShowHomeTeam()
        {
            Btn_HomeTeamInnings1.BackgroundColor = Color.FromHex("#2196F3");
            Btn_HomeTeamInnings1.TextColor = Color.FromHex("#fff");
            Btn_AwayTeamInnings1.BackgroundColor = Color.FromHex("#fff");
            Btn_AwayTeamInnings1.TextColor = Color.FromHex("#2196F3");
            HomeTeamInningsLayout.IsVisible = true;
            AwayTeamInningsLayout.IsVisible = false;
        }

        private void ShowAwayTeam()
        {
            Btn_AwayTeamInnings1.BackgroundColor = Color.FromHex("#2196F3");
            Btn_AwayTeamInnings1.TextColor = Color.FromHex("#fff");
            Btn_HomeTeamInnings1.BackgroundColor = Color.FromHex("#fff");
            Btn_HomeTeamInnings1.TextColor = Color.FromHex("#2196F3");
            AwayTeamInningsLayout.IsVisible = true;
            HomeTeamInningsLayout.IsVisible = false;
        }
    }
}