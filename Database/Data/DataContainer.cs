using RugbyManagementSystem.Database.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace RugbyManagementSystem.Database.Data
{
    public static class DataContainer
    {
        public static DataBase dataBase = new DataBase();
        public static List<JuniorPlayerModel> JuniorPlayers = dataBase.SelectFromJuniorPlayersTable();
        public static List<PlayerModel> AdultPlayers = dataBase.SelectFromPlayersTable();
        public static List<PlayerModel> Players = new List<PlayerModel>();
        public static List<TeamModel> Teams = dataBase.SelectFromTeamsTable();
        public static List<MemberModel> Members = new List<MemberModel>();
        public static List<CoachModel> Coaches = dataBase.SelectFromCoachesTable();
        public static List<UserModel> Users = dataBase.SelectFromUsersTable();
        


        public static void UpdateMembersList()
        {
            Members.Clear();
            foreach(MemberModel x in JuniorPlayers)
            {
                Members.Add(x);
            }
            foreach (MemberModel x in AdultPlayers)
            {
                Members.Add(x);
            }
            foreach (MemberModel x in Coaches)
            {
                Members.Add(x);
            }
        }
        public static void UpdatePlayersList()
        {
            Players.Clear();
            foreach (PlayerModel y in AdultPlayers)
            {
                Players.Add(y);
            }
            foreach (PlayerModel x in JuniorPlayers)
            {
                Players.Add(x);
            }   
        }
        public static void UpdateJuniorPlayersList()
        {
            JuniorPlayers.Clear();
            JuniorPlayers = dataBase.SelectFromJuniorPlayersTable();
        }
        public static void UpdateAdultPlayersList()
        {
            AdultPlayers.Clear();
            AdultPlayers = dataBase.SelectFromPlayersTable();
        }
        public static void UpdateCoachesList()
        {
            Coaches = dataBase.SelectFromCoachesTable();
        }
        public static void UpdateTeamsList()
        {
            Teams.Clear();
            foreach(TeamModel x in dataBase.SelectFromTeamsTable())
            {
                Teams.Add(x);
            }
        }

    }
}
