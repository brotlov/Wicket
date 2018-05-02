using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Wicket.Models
{
    public class DateItem
    {
        public DateTime Date {get;set;}
        public string Text {get;set;}
        public ObservableCollection<Match> MatchList {get;set;}
    }
}