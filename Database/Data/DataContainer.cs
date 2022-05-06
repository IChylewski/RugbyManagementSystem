using RugbyManagementSystem.Database.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace RugbyManagementSystem.Database.Data
{
    // This is static DataContainer class that refers to DataBase class and stores all entries from SQL in the lists
    public static class DataContainer
    {
        public static DataBase dataBase = new DataBase();          // Instance of DataBase Object

        // Lists that stores tables' records
        public static List<JuniorPlayerModel> JuniorPlayers = dataBase.SelectFromJuniorPlayersTable(); // List is populated with all records of specific table
        public static List<PlayerModel> AdultPlayers = dataBase.SelectFromPlayersTable();
        public static List<PlayerModel> Players = new List<PlayerModel>();
        public static List<TeamModel> Teams = dataBase.SelectFromTeamsTable();
        public static List<MemberModel> Members = new List<MemberModel>();
        public static List<CoachModel> Coaches = dataBase.SelectFromCoachesTable();
        public static List<UserModel> Users = dataBase.SelectFromUsersTable();
        


        public static void UpdateMembersList()  // Put all members - Adult Players, Junior Players and Coaches in one list 
        {
            Members.Clear();         // Must be cleared every time method is invoked to avoid populating with same records
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
        public static void UpdatePlayersList()  // Put all players - Junior and Adult in one list 
        {
            Players.Clear();                  // Must be cleared every time method is invoked to avoid populating with same records
            foreach (PlayerModel y in AdultPlayers)
            {
                y.FindTeamName();         // Refresh current name of the team 
                Players.Add(y);
            }
            foreach (PlayerModel x in JuniorPlayers)
            {
                x.FindTeamName();            // Refresh current name of the team 
                Players.Add(x);
            }   
        }
        public static void UpdateJuniorPlayersList()   // Selects all records from Junior Players Table and puts it into list - to be used as list update
        {
            JuniorPlayers.Clear();
            JuniorPlayers = dataBase.SelectFromJuniorPlayersTable(); 
        }
        public static void UpdateAdultPlayersList()      // Selects all records from Adult Players Table and puts it into list - to be used as list update
        {
            AdultPlayers.Clear();
            AdultPlayers = dataBase.SelectFromPlayersTable();
        }
        public static void UpdateCoachesList()          // Selects all records from Coaches  Table and puts it into list - to be used as list update
        {
            Coaches.Clear();
            Coaches = dataBase.SelectFromCoachesTable();
        }
        public static void UpdateTeamsList()          // Selects all records from Teams  Table and puts it into list - to be used as list update
        {                                             // Coded in this way because previous didn't update lists properly idk why
            Teams.Clear();
            foreach(TeamModel x in dataBase.SelectFromTeamsTable())
            {
                Teams.Add(x);
            }
        }

    }
}
