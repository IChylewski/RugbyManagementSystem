using RugbyManagementSystem.Database.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace RugbyManagementSystem.Database.Data
{
    class DataContainer
    {
        public List<PlayerModel> Players { get; set; }
        public List<TeamModel> Teams { get; set; }

        public DataContainer()
        {
            Players = new List<PlayerModel>();
            Teams = new List<TeamModel>();


            Players.Add(new PlayerModel
            {
                ID = "1",
                Name = "Irek Chylewski",
                Team = "Lizards",
                Age = "16",
                Type = "Junior",
                OverallSkill = "3.2"
            });

            Players.Add(new PlayerModel
            {
                ID = "2",
                Name = "Adrian Szramka",
                Team = "Dragons",
                Age = "25",
                Type = "Adult",
                OverallSkill = "4"
            });

            Players.Add(new PlayerModel
            {
                ID = "3",
                Name = "Erika Silvanovic",
                Team = "Monkeys",
                Age = "12",
                Type = "Junior",
                OverallSkill = "2"
            });

            Teams.Add(new TeamModel
            {
                ID = "1",
                Name = "Dragons",
                PlayersNumber = "10/50"
            });

            Teams.Add(new TeamModel
            {
                ID = "2",
                Name = "Lizards",
                PlayersNumber = "10/50"
            });

            Teams.Add(new TeamModel
            {
                ID = "3",
                Name = "Monkeys",
                PlayersNumber = "10/50"
            });


        }
    }
}
