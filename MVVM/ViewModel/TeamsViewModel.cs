using RugbyManagementSystem.Core;
using RugbyManagementSystem.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RugbyManagementSystem.MVVM.ViewModel
{
    class TeamsViewModel : ObservableObject
    {
        public ObservableCollection<TeamModel> Teams { get; set; }

    }
}
