using RugbyManagementSystem.Database.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace RugbyManagementSystem.Database.Data
{
    class DataContainer
    {
        private DataBase dataBase;
        public List<MemberModel> Members { get; set; }
        public List<PlayerModel> Players { get; set; }
        public List<TeamModel> Teams { get; set; }
        public List<UserModel> Users { get; set; }

        public DataContainer()
        {
            dataBase = new DataBase();

            Users = dataBase.SelectFromUsersTable();
            Members = new List<MemberModel>();
            Players = new List<PlayerModel>();
            Teams = new List<TeamModel>();

            Members.Add(new MemberModel
            (
                1,
                "Irek",
                "Chylewski",
                "irekchylewski@gmail.com",
                new System.DateTime(1997, 09, 23),
                "Adult Player",
                "07746252576",
                "52425235224"
            ));

            Members.Add(new MemberModel
            (
                2,
                "Erika",
                "Silvanovic",
                "erikasilvanovic@gmail.com",
                new System.DateTime(1997, 09, 23),
                "Junior Player",
                "07746252576",
                "52425235224",
                "Yes"
            ));

            Members.Add(new MemberModel
            (
                3,
                "Adrian",
                "Szramka",
                "adrianszramka@gmail.com",
                new System.DateTime(1997, 09, 23),
                "Coach",
                "07746252576"
            ));

            Members.Add(new MemberModel
            (
                4,
                "Mateusz",
                "Neumann",
                "mateuszneumann@gmail.com",
                new System.DateTime(1997, 09, 23),
                "Adult Player",
                "07746252576",
                "52425235224"
            ));

            Members.Add(new MemberModel
            (
                5,
                "Pawel",
                "Wisniewski",
                "pawelwisniewski@gmail.com",
                new System.DateTime(1997, 09, 23),
                "Adult Player",
                "07746252576",
                "52425235224"
            ));


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
