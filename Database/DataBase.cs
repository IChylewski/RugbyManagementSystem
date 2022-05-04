using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows;
using RugbyManagementSystem.Database.Models;

namespace RugbyManagementSystem.Database
{
    public class DataBase
    {
        SQLiteConnection dbConnection;
        public DataBase()
        {
            if(!System.IO.File.Exists("./database.sqlite"))
            {
                SQLiteConnection.CreateFile("database.sqlite");
                MessageBox.Show("database Created");
            }

            dbConnection = new SQLiteConnection("Data Source=database.sqlite");
            dbConnection.Open();

            //DropUsersTable();
            //CreateUsersTable();

            //DropTeamsTable();
            //CreateTeamsTable();

           // DropCoachesTable();
            //CreateCoachesTable();

            //DropPlayersTable();
            //CreatePlayersTable();

            //DropJuniorPlayersTable();
            //CreateJuniorPlayersTable();

            //DropMembersTable();
            //CreateMembersTable();
        }

        public void CreateUsersTable()
        {

            string sql = "CREATE TABLE Users(id INTEGER PRIMARY KEY, Login TEXT, Password TEXT)";
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();

            sql = "INSERT INTO Users (Login,Password) VALUES ('Coach', 'Coach123')";
            command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();

            sql = "INSERT INTO Users (Login,Password) VALUES ('Secretary', 'Secretary123')";
            command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();

        }
        public void DropUsersTable()
        {

            string sql = "DROP TABLE IF EXISTS Users";
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();

        }
        public List<UserModel> SelectFromUsersTable()
        {

            List<UserModel> UsersList = new List<UserModel>();

            string sql = "SELECT * from Users";
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);

            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                UsersList.Add(new UserModel(reader.GetInt32(0), reader.GetString(1), reader.GetString(2)));
            }


            return UsersList;
        }


        public void CreateCoachesTable()
        {
            string sql = "CREATE TABLE Coaches(id INTEGER PRIMARY KEY, FirstName TEXT, LastName TEXT, Email TEXT, DOB TEXT, PhoneNumber TEXT)";
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();

            sql = "INSERT INTO Coaches (FirstName, LastName, Email, DOB, PhoneNumber) VALUES ('Irek', 'Chylewski', 'irekchylewski@gmail.com', '23/09/1990', '07746252576')";
            command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();

            sql = "INSERT INTO Coaches (FirstName, LastName, Email, DOB, PhoneNumber) VALUES ('Erika', 'Silvanovic', 'erikasilvanovic@gmail.com', '25/04/1990', '07346232576')";
            command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();

        }
        public void DropCoachesTable()
        {
            string sql = "DROP TABLE IF EXISTS Coaches";
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();
        }
        public List<CoachModel> SelectFromCoachesTable()
        {

            List<CoachModel> CoachesList = new List<CoachModel>();

            string sql = "SELECT * from Coaches";
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);

            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                CoachesList.Add(new CoachModel(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5)));
            };


            return CoachesList;
        }
        public void AddNewCoach(string firstName, string lastName, string email, string dob, string phoneNumber)
        {
            string sql = $"INSERT INTO Coaches(FirstName, LastName, Email, DOB, PhoneNumber) VALUES ('{firstName}','{lastName}','{email}','{dob}','{phoneNumber}')";

            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();
        }
        public void EditCoach(int id, string firstName, string lastName, string email, string dob, string phoneNumber)
        {
            string sql = $"UPDATE Coaches SET FirstName = '{firstName}', LastName = '{lastName}', Email = '{email}', DOB = '{dob}', PhoneNumber = '{phoneNumber}' WHERE ID = '{id}'";

            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();
        }
        public void DeleteCoach(int id)
        {
            string sql = $"DELETE FROM Coaches WHERE ID = '{id}'";

            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();
        }


        public void CreateTeamsTable()
        {
            string sql = "CREATE TABLE Teams(id INTEGER PRIMARY KEY, Name TEXT)";
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();

            sql = "INSERT INTO Teams (Name) VALUES ('Dragons')";
            command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();

            sql = "INSERT INTO Teams (Name) VALUES ('Lizards')";
            command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();
        }
        public void DropTeamsTable()
        {
            string sql = "DROP TABLE IF EXISTS Teams";
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();
        }
        public List<TeamModel> SelectFromTeamsTable()
        {
            List<TeamModel> TeamsList = new List<TeamModel>();

            string sql = "SELECT * from Teams";
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);

            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                TeamsList.Add(new TeamModel(reader.GetInt32(0), reader.GetString(1)));
            }
            return TeamsList;
        }
        public void AddNewTeam(string name)
        {
            string sql = $"INSERT INTO Teams(Name) VALUES ('{name}')";

            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();
        }
        public void EditTeam(int id, string name)
        {
            string sql = $"UPDATE Teams SET Name = '{name}' WHERE ID = '{id}'";

            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();
        }
        public void DeleteTeam(int id)
        {
            string sql = $"DELETE FROM Teams WHERE ID = '{id}'";

            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();
        }


        public void CreatePlayersTable()
        {
            string sql = "CREATE TABLE Players(id INTEGER PRIMARY KEY, FirstName TEXT, LastName TEXT, Email TEXT, DOB TEXT, PhoneNumber TEXT, SRUNumber TEXT, TeamID INTEGER DEFAULT '0', StandardPass INTEGER DEFAULT '0', SpinPass INTEGER DEFAULT '0', PopPass INTEGER DEFAULT '0', FrontTackle INTEGER DEFAULT '0', RearTackle INTEGER DEFAULT '0', SideTackle INTEGER DEFAULT '0', ScrabbleTackle INTEGER DEFAULT '0', DropKick INTEGER DEFAULT '0', PuntKick INTEGER DEFAULT '0', GrubberKick INTEGER DEFAULT '0', GoalKick INTEGER DEFAULT '0')";
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();

        }
        public void DropPlayersTable()
        {
            string sql = "DROP TABLE IF EXISTS Players";
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();
        }
        public List<PlayerModel> SelectFromPlayersTable()
        {
            List<PlayerModel> PlayersList = new List<PlayerModel>();

            string sql = "SELECT * from Players";
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);

            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                PlayersList.Add(new PlayerModel(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetInt32(7),reader.GetInt32(8), reader.GetInt32(9), reader.GetInt32(10), reader.GetInt32(11), reader.GetInt32(12), reader.GetInt32(13), reader.GetInt32(14), reader.GetInt32(15), reader.GetInt32(16), reader.GetInt32(17), reader.GetInt32(18)));
            };


            return PlayersList;
        }
        public void AddNewPlayer(string firstName, string lastName, string email, string dob, string phoneNumber, string sruNumber)
        {
            string sql = $"INSERT INTO Players(FirstName, LastName, Email, DOB, PhoneNumber, SRUNumber) VALUES ('{firstName}','{lastName}','{email}','{dob}','{phoneNumber}','{sruNumber}')";

            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();
        }
        public void EditPlayer (int id, string firstName, string lastName, string email, string dob, string phoneNumber,string sruNumber)
        {
            string sql = $"UPDATE Players SET FirstName = '{firstName}', LastName = '{lastName}', Email = '{email}', DOB = '{dob}', PhoneNumber = '{phoneNumber}', SRUNumber = '{sruNumber}' WHERE ID = '{id}'";

            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();
        }
        public void EditPlayerDevelopment (int id, int standardPass, int spinPass, int popPass, int frontTackle, int rearTackle, int sideTackle, int scrabbleTackle, int dropKick, int puntKick, int grubberKick,int goalKick)
        {
            string sql = $"UPDATE Players SET StandardPass = '{standardPass}', SpinPass = '{spinPass}', PopPass = '{popPass}', FrontTackle = '{frontTackle}', RearTackle = '{rearTackle}', SideTackle = '{sideTackle}', ScrabbleTackle = '{scrabbleTackle}', DropKick = '{dropKick}', PuntKick = '{puntKick}', GrubberKick = '{grubberKick}', GoalKick = '{goalKick}' WHERE ID = '{id}'";

            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();
        }
        public void DeletePlayer(int id)
        {
            string sql = $"DELETE FROM Players WHERE ID = '{id}'";

            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();
        }
        public void ChangePlayerTeam(int id, int teamID)
        {
            string sql = $"UPDATE Players SET  TeamID = '{teamID}' WHERE ID = '{id}'";

            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();
        }



        public void CreateJuniorPlayersTable()
        {
            string sql = "CREATE TABLE JuniorPlayers(id INTEGER PRIMARY KEY, FirstName TEXT, LastName TEXT, Email TEXT, DOB TEXT, PhoneNumber TEXT, SRUNumber TEXT, Consent TEXT, TeamID INTEGER DEFAULT '0', StandardPass INTEGER DEFAULT '0', SpinPass INTEGER DEFAULT '0', PopPass INTEGER DEFAULT '0', FrontTackle INTEGER DEFAULT '0', RearTackle INTEGER DEFAULT '0', SideTackle INTEGER DEFAULT '0', ScrabbleTackle INTEGER DEFAULT '0', DropKick INTEGER DEFAULT '0', PuntKick INTEGER DEFAULT '0', GrubberKick INTEGER DEFAULT '0', GoalKick INTEGER DEFAULT '0')";
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();

        }
        public void DropJuniorPlayersTable()
        {
            string sql = "DROP TABLE IF EXISTS JuniorPlayers";
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();
        }
        public List<JuniorPlayerModel> SelectFromJuniorPlayersTable()
        {
            List<JuniorPlayerModel> JuniorPlayersList = new List<JuniorPlayerModel>();

            string sql = "SELECT * from JuniorPlayers";
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);

            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                JuniorPlayersList.Add(new JuniorPlayerModel(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7), reader.GetInt32(8), reader.GetInt32(9), reader.GetInt32(10), reader.GetInt32(11), reader.GetInt32(12), reader.GetInt32(13), reader.GetInt32(14), reader.GetInt32(15), reader.GetInt32(16), reader.GetInt32(17), reader.GetInt32(18), reader.GetInt32(19)));
            };

            return JuniorPlayersList;
        }
        public void AddNewJuniorPlayer(string firstName, string lastName, string email, string dob, string phoneNumber, string sruNumber, string consent)
        {
            string sql = $"INSERT INTO JuniorPlayers(FirstName, LastName, Email, DOB, PhoneNumber, SRUNumber, Consent) VALUES ('{firstName}','{lastName}','{email}','{dob}','{phoneNumber}','{sruNumber}','{consent}')";

            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();
        }
        public void EditJuniorPlayer(int id, string firstName, string lastName, string email, string dob, string phoneNumber, string sruNumber,string consent)
        {
            string sql = $"UPDATE JuniorPlayers SET FirstName = '{firstName}', LastName = '{lastName}', Email = '{email}', DOB = '{dob}', PhoneNumber = '{phoneNumber}', SRUNumber = '{sruNumber}', Consent = '{consent}' WHERE ID = '{id}'";

            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();
        }
        public void EditJuniorPlayerDevelopment(int id, int standardPass, int spinPass, int popPass, int frontTackle, int rearTackle, int sideTackle, int scrabbleTackle, int dropKick, int puntKick, int grubberKick, int goalKick)
        {
            string sql = $"UPDATE JuniorPlayers SET StandardPass = '{standardPass}', SpinPass = '{spinPass}', PopPass = '{popPass}', FrontTackle = '{frontTackle}', RearTackle = '{rearTackle}', SideTackle = '{sideTackle}', ScrabbleTackle = '{scrabbleTackle}', DropKick = '{dropKick}', PuntKick = '{puntKick}', GrubberKick = '{grubberKick}', GoalKick = '{goalKick}' WHERE ID = '{id}'";

            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();
        }
        public void DeleteJuniorPlayer(int id)
        {
            string sql = $"DELETE FROM JuniorPlayers WHERE ID = '{id}'";

            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();
        }
        public void ChangeJuniorPlayerTeam(int id, int teamID)
        {
            string sql = $"UPDATE JuniorPlayers SET  TeamID = '{teamID}' WHERE ID = '{id}'";

            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();
        }

    }
}
