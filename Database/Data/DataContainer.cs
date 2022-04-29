using RugbyManagementSystem.Database.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace RugbyManagementSystem.Database.Data
{
    class DataContainer
    {
        public DataBase dataBase;
        public List<MemberModel> Members { get; set; }
        public List<PlayerModel> Players { get; set; }
        public List<TeamModel> Teams { get; set; }
        public List<UserModel> Users { get; set; }

        public DataContainer()
        {
            dataBase = new DataBase();

            Users = dataBase.SelectFromUsersTable();
            Members = dataBase.SelectFromMembersTable();
            Players = new List<PlayerModel>();
            Teams = new List<TeamModel>();


            Teams.Add(new TeamModel
            (
                1,
                "Dragons"
            ));

            Teams.Add(new TeamModel
            (
                2,
                "Lizards"
            ));

            Teams.Add(new TeamModel
            (
                3,
                "Monkeys"
            ));


        }
    }
}
