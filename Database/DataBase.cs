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
    class DataBase
    {
        SQLiteConnection dbConnection;
        public DataBase()
        {
            if(!System.IO.File.Exists("./database.sqlite"))
            {
                SQLiteConnection.CreateFile("database.sqlite");
                MessageBox.Show("Database Created");
            }

            dbConnection = new SQLiteConnection("Data Source=database.sqlite");
            dbConnection.Open();

            //DropUsersTable();
            //CreateUsersTable();
            //SelectFromUsersTable();


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
                //MessageBox.Show($"{reader.GetInt32(0)} {reader.GetString(1)} {reader.GetString(2)}");
            }

            return UsersList;
        }

    }
}
