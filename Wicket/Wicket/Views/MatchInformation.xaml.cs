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

namespace Wicket.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MatchInformation : TabbedPage
    {
        public MatchInformation (Match selectedMatch)
        {
            InitializeComponent();
            BindingContext = selectedMatch;
        }
    }
}