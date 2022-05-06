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
            if(!System.IO.File.Exists("./database.sqlite"))            // checks if database file is created if not - creates new database
            {
                SQLiteConnection.CreateFile("database.sqlite");
                MessageBox.Show("database Created");
            }

            dbConnection = new SQLiteConnection("Data Source=database.sqlite");         // Sets connection with database
            dbConnection.Open();

            // The commented methods below allows to recreate whole database quickly
            // DELETES ALL RECORDS!!!

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

        }

        public void CreateUsersTable()               // Creates Users Table
        {

            string sql = "CREATE TABLE Users(id INTEGER PRIMARY KEY, Login TEXT, Password TEXT)";       // It is query that is sent to sql database
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();

            sql = "INSERT INTO Users (Login,Password) VALUES ('coach', 'coach123')";  // Adds new users to database
            command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();

            sql = "INSERT INTO Users (Login,Password) VALUES ('admin', 'admin123')";
            command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();

        }
        public void DropUsersTable()        // Deletes table
        {

            string sql = "DROP TABLE IF EXISTS Users";
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();

        }
        public List<UserModel> SelectFromUsersTable()            // Selects all records from Users Table and put them into the list - then list is returned by method
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


        public void CreateCoachesTable() // Creates Coaches Table
        {
            string sql = "CREATE TABLE Coaches(id INTEGER PRIMARY KEY, FirstName TEXT, LastName TEXT, Email TEXT, DOB TEXT, PhoneNumber TEXT)";
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();
             
            sql = "INSERT INTO Coaches (FirstName, LastName, Email, DOB, PhoneNumber) VALUES ('Irek', 'Chylewski', 'irekchylewski@gmail.com', '23/09/1990', '07746252576')";         // Adds new coaches to database
            command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();

            sql = "INSERT INTO Coaches (FirstName, LastName, Email, DOB, PhoneNumber) VALUES ('Erika', 'Silvanovic', 'erikasilvanovic@gmail.com', '25/04/1990', '07346232576')";
            command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();

        }
        public void DropCoachesTable() // Deletes Coaches Table
        {
            string sql = "DROP TABLE IF EXISTS Coaches";
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();
        }
        public List<CoachModel> SelectFromCoachesTable() // Selects all records from Coaches Table and put them into the list - then list is returned by method
        {

            List<CoachModel> CoachesList = new List<CoachModel>();

            string sql = "SELECT * from Coaches";
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);

            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())      // Read function reads rows in the table one by one and returns true if the next row is sucesfully loaded and false if not
            {
                CoachesList.Add(new CoachModel(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5)));
            };


            return CoachesList;
        }
        public void AddNewCoach(string firstName, string lastName, string email, string dob, string phoneNumber)  // Adds new Coach record to the Coaches table
        {
            string sql = $"INSERT INTO Coaches(FirstName, LastName, Email, DOB, PhoneNumber) VALUES ('{firstName}','{lastName}','{email}','{dob}','{phoneNumber}')";

            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();
        }
        public void EditCoach(int id, string firstName, string lastName, string email, string dob, string phoneNumber)  // Edits record in Coaches table
        {
            string sql = $"UPDATE Coaches SET FirstName = '{firstName}', LastName = '{lastName}', Email = '{email}', DOB = '{dob}', PhoneNumber = '{phoneNumber}' WHERE ID = '{id}'";

            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();
        }
        public void DeleteCoach(int id)          // Deletes record from coaches table
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
        public void AddNewTeam(string name)        // Adds new Team record to the Teams table
        {
            string sql = $"INSERT INTO Teams(Name) VALUES ('{name}')";

            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();
        }     
        public void EditTeam(int id, string name)         // Edits record in Teams table
        {
            string sql = $"UPDATE Teams SET Name = '{name}' WHERE ID = '{id}'";

            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();
        }
        public void DeleteTeam(int id)       // Deletes record from teams table
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

        }   // Creates Players table
        public void DropPlayersTable()
        {
            string sql = "DROP TABLE IF EXISTS Players";
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();
        }    // Deletes Players table
        public List<PlayerModel> SelectFromPlayersTable()    // Selects all records from Players Table and put them into the list - then list is returned by method
        {
            List<PlayerModel> PlayersList = new List<PlayerModel>();

            string sql = "SELECT * from Players";
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);

            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())             // Read function reads rows in the table one by one and returns true if the next row is sucesfully loaded and false if not
            {
                PlayersList.Add(new PlayerModel(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetInt32(7),reader.GetInt32(8), reader.GetInt32(9), reader.GetInt32(10), reader.GetInt32(11), reader.GetInt32(12), reader.GetInt32(13), reader.GetInt32(14), reader.GetInt32(15), reader.GetInt32(16), reader.GetInt32(17), reader.GetInt32(18)));
            };


            return PlayersList;
        }
        public void AddNewPlayer(string firstName, string lastName, string email, string dob, string phoneNumber, string sruNumber)     // Add new record to players table
        {
            string sql = $"INSERT INTO Players(FirstName, LastName, Email, DOB, PhoneNumber, SRUNumber) VALUES ('{firstName}','{lastName}','{email}','{dob}','{phoneNumber}','{sruNumber}')";

            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();
        }
        public void EditPlayer (int id, string firstName, string lastName, string email, string dob, string phoneNumber,string sruNumber)     // Edit record in the Players table
        {
            string sql = $"UPDATE Players SET FirstName = '{firstName}', LastName = '{lastName}', Email = '{email}', DOB = '{dob}', PhoneNumber = '{phoneNumber}', SRUNumber = '{sruNumber}' WHERE ID = '{id}'";

            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();
        }
        public void EditPlayerDevelopment (int id, int standardPass, int spinPass, int popPass, int frontTackle, int rearTackle, int sideTackle, int scrabbleTackle, int dropKick, int puntKick, int grubberKick,int goalKick) // Edit Player's skills in the Players table
        {
            string sql = $"UPDATE Players SET StandardPass = '{standardPass}', SpinPass = '{spinPass}', PopPass = '{popPass}', FrontTackle = '{frontTackle}', RearTackle = '{rearTackle}', SideTackle = '{sideTackle}', ScrabbleTackle = '{scrabbleTackle}', DropKick = '{dropKick}', PuntKick = '{puntKick}', GrubberKick = '{grubberKick}', GoalKick = '{goalKick}' WHERE ID = '{id}'";

            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();
        }
        public void DeletePlayer(int id)  // Deletes record from Player table
        {
            string sql = $"DELETE FROM Players WHERE ID = '{id}'";

            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();
        }
        public void ChangePlayerTeam(int id, int teamID)         // Changes teamID value of the records in the Players Table
        {
            string sql = $"UPDATE Players SET  TeamID = '{teamID}' WHERE ID = '{id}'";

            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();
        }



        public void CreateJuniorPlayersTable()      // Creates Junior Players table
        {
            string sql = "CREATE TABLE JuniorPlayers(id INTEGER PRIMARY KEY, FirstName TEXT, LastName TEXT, Email TEXT, DOB TEXT, PhoneNumber TEXT, SRUNumber TEXT, Consent TEXT, TeamID INTEGER DEFAULT '0', StandardPass INTEGER DEFAULT '0', SpinPass INTEGER DEFAULT '0', PopPass INTEGER DEFAULT '0', FrontTackle INTEGER DEFAULT '0', RearTackle INTEGER DEFAULT '0', SideTackle INTEGER DEFAULT '0', ScrabbleTackle INTEGER DEFAULT '0', DropKick INTEGER DEFAULT '0', PuntKick INTEGER DEFAULT '0', GrubberKick INTEGER DEFAULT '0', GoalKick INTEGER DEFAULT '0')";
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();

        }
        public void DropJuniorPlayersTable()        // Deletes Junior Players table
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
        }      // Selects all records from Junior Players Table and put them into the list - then list is returned by method
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
        }  // Edit Junior Player's deails in the Players table
        public void EditJuniorPlayerDevelopment(int id, int standardPass, int spinPass, int popPass, int frontTackle, int rearTackle, int sideTackle, int scrabbleTackle, int dropKick, int puntKick, int grubberKick, int goalKick)  // Edit Junior Player's skills in the Players table
        {
            string sql = $"UPDATE JuniorPlayers SET StandardPass = '{standardPass}', SpinPass = '{spinPass}', PopPass = '{popPass}', FrontTackle = '{frontTackle}', RearTackle = '{rearTackle}', SideTackle = '{sideTackle}', ScrabbleTackle = '{scrabbleTackle}', DropKick = '{dropKick}', PuntKick = '{puntKick}', GrubberKick = '{grubberKick}', GoalKick = '{goalKick}' WHERE ID = '{id}'";

            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();
        }
        public void DeleteJuniorPlayer(int id)        //Deletes record from Junior Players Table
        {
            string sql = $"DELETE FROM JuniorPlayers WHERE ID = '{id}'";

            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();
        }
        public void ChangeJuniorPlayerTeam(int id, int teamID)      // Changes teamID value of the records in the Junior Players Table
        {
            string sql = $"UPDATE JuniorPlayers SET  TeamID = '{teamID}' WHERE ID = '{id}'";

            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();
        }

    }
}
