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
    class PlayersViewModel : ObservableObject
    {
        public ObservableCollection<PlayerModel> Players { get; set; }
        public PlayersViewModel()
        {
            Players = new ObservableCollection<PlayerModel>();

            Players.Add(new PlayerModel
            {
                ID = "1",
                Name = "Irek Chylewski",
                Team = "Lizards",
                Age = 15,
                OverallSkill = 3,
                Type = "Junior"
            });
            Players.Add(new PlayerModel
            {
                ID = "2",
                Name = "Erika Silvanovic",
                Team = "Lizards",
                Age = 18,
                OverallSkill = 5,
                Type = "Adult"
            });
            Players.Add(new PlayerModel
            {
                ID = "3",
                Name = "Adrian Szramka",
                Team = "Lizards",
                Age = 25,
                OverallSkill = 1,
                Type = "Adult"
            });
        }
    }
}
