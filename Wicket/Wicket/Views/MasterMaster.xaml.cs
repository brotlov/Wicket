using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Wicket
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterMaster : ContentPage
    {
        public ListView ListView;

        public MasterMaster()
        {
            InitializeComponent();

            BindingContext = new MasterMasterViewModel();
            ListView = MenuItemsListView;
        }

        class MasterMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MasterMenuItem> MenuItems { get; set; }
            
            public MasterMasterViewModel()
            {
                MenuItems = new ObservableCollection<MasterMenuItem>(new[]
                {
                    new MasterMenuItem { Id = 0, Title = "Games", TargetType = typeof(Games) },
                    new MasterMenuItem { Id = 1, Title = "Settings", TargetType = typeof(Settings) },
                    new MasterMenuItem { Id = 2, Title = "Donate", TargetType = typeof(Donate) },
                });
            }
            
            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}