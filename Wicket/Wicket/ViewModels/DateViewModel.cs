using Wicket.Models;
using Wicket.ViewModels;
using Wicket.Helpers;
using System.Collections.ObjectModel;
using System.Linq;

namespace Wicket.ViewModels
{
    public class DateViewModel
    {
        public ObservableCollection<DateItem> Dates { get; set; }

        public DateViewModel()
        {
            Dates = WicketHelper.Dates;
        }
    }
}