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
            BindingContext = selectedMatch;

            var task = GetScoreCard(selectedMatch);
            Task.Run(async () => {
                try
                {
                    await GetScoreCard(selectedMatch);
                }
                catch (System.OperationCanceledException ex)
                {
                    Console.WriteLine($"Text load cancelled: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            });

        }

        async Task GetScoreCard(Match match)
        {
            await WicketHelper.GetScorecardAsync(match);
            ScorecardLoading.IsRunning = false;
            ScorecardLoading.IsVisible = false;
        }
    }
}