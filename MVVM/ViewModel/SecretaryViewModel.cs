using RugbyManagementSystem.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RugbyManagementSystem.MVVM.ViewModel
{
    class SecretaryViewModel : ObservableObject
    {
        public RelayCommand MembersViewCommand { get; set; }
        public RelayCommand TeamsViewCommand { get; set; }
        public RelayCommand EmailsViewCommand { get; set; }


        public EmailsViewModel EmailsVM { get; set; }
        public TeamsViewModel TeamsVM { get; set; }
        public MembersViewModel MembersVM { get; set; }
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

        public SecretaryViewModel()
        {
            MembersVM = new MembersViewModel();
            TeamsVM = new TeamsViewModel();
            EmailsVM = new EmailsViewModel();
            CurrentView = MembersVM;

            MembersViewCommand = new RelayCommand(o =>
            {
                CurrentView = MembersVM;
            });

            TeamsViewCommand = new RelayCommand(o =>
            {
                CurrentView = TeamsVM;
            });

            EmailsViewCommand = new RelayCommand(o =>
            {
                CurrentView = EmailsVM;
            });
        }
    }
}
