using PersonalManager.Entities;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PersonalManager.Database
{
    public static class DatabaseLoader
    {

        public static SQLiteConnection Connection;


        static DatabaseLoader()
        {
            var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "MyData.db");
            Connection = new SQLiteConnection(databasePath);
            Connection.CreateTable<TaskItem>();
            Connection.CreateTable<Contact>();

        }
    }
}
