﻿using System;
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
        public List<MemberModel> SelectFromMembersTable()
        {
            List<MemberModel> MembersList = new List<MemberModel>();

            string sql = "SELECT * from Members";
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);

            SQLiteDataReader reader = command.ExecuteReader();

            while(reader.Read())
            {
                MembersList.Add(new MemberModel(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7), reader.GetString(8)));
            };

            return MembersList;
        }

        public void CreateMembersTable()
        {
            string sql = "CREATE TABLE Members(id INTEGER PRIMARY KEY, FirstName TEXT, LastName TEXT, Email TEXT, DOB TEXT, Type TEXT, PhoneNumber TEXT, SRUNumber TEXT, Consent TEXT)";
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();

            sql = "INSERT INTO Members (FirstName, LastName, Email, DOB, Type, PhoneNumber, SRUNumber, Consent) VALUES ('Irek', 'Chylewski', 'irekchylewski@gmail.com', '23/09/1997', 'Adult Player', '07746252576', '07746252576', 'Not required' )";
            command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();

            sql = "INSERT INTO Members (FirstName, LastName, Email, DOB, Type, PhoneNumber, SRUNumber, Consent) VALUES ('Erika', 'Silvanovic', 'erikasilvanovic@gmail.com', '25/04/2005', 'Junior Player', '07346232576', '52432125224', 'Yes' )";
            command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();

            sql = "INSERT INTO Members (FirstName, LastName, Email, DOB, Type, PhoneNumber, SRUNumber, Consent) VALUES ('Adrian', 'Szramka', 'adrianszramka@gmail.com', '23/09/1993', 'Coach', '07136152876', '', 'Not required' )";
            command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();
        }

        public void DropMembersTable()
        {
            string sql = "DROP TABLE IF EXISTS Members";
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();
        }
        public void AddNewMember(string firstName, string lastName, string email, string dob, string type, string phoneNumber, string sruNumber, string consent)
        {
            string sql = $"INSERT INTO Members(FirstName, LastName, Email, DOB, Type, PhoneNumber, SRUNumber, Consent) VALUES ('{firstName}','{lastName}','{email}','{dob}','{type}','{phoneNumber}','{sruNumber}','{consent}')";

            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();
        }

    }
}
