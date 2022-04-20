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

        public TeamsViewModel()
        {
            Teams = new ObservableCollection<TeamModel>();

            Teams.Add(new TeamModel
            {
                ID = "1",
                TeamName = "Power Rangers",
                Players = "13/50"
            });
            Teams.Add(new TeamModel
            {
                ID = "1",
                TeamName = "Dragons",
                Players = "26/50"

            });
            Teams.Add(new TeamModel
            {
                ID = "1",
                TeamName = "FC Lizards",
                Players = "49/50"
            });
        }
    }
}
