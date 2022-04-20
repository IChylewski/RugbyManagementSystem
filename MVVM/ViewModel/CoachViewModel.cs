using RugbyManagementSystem.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RugbyManagementSystem.MVVM.ViewModel
{
    class CoachViewModel : ObservableObject
    {
        public RelayCommand PlayersViewCommand { get; set; }
        public RelayCommand SquadsViewCommand { get; set; }


        public PlayersViewModel PlayersVM { get; set; }
        public SquadsViewModel SquadsVM { get; set; }
        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public CoachViewModel()
        {
            PlayersVM = new PlayersViewModel();
            SquadsVM = new SquadsViewModel();
            CurrentView = PlayersVM;

            PlayersViewCommand = new RelayCommand(o =>
            {
                CurrentView = PlayersVM;
            });

            SquadsViewCommand = new RelayCommand(o =>
            {
                CurrentView = SquadsVM;
            });;
        }
    }
}
