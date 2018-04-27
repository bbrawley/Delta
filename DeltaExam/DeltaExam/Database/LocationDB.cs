using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using DeltaExam.Classes;

namespace DeltaExam
{
    public class LocationDB
    {
        private SQLiteConnection conn;
        public string StatusMessage { get; set; }

        public LocationDB(string dbPath)
        {
            conn = new SQLiteConnection(dbPath);
            conn.CreateTable<FavoriteLocations>();
        }
        public void SaveFavoriteLocation(FavoriteLocations location)
        {
            conn.Insert(location);
        }

    }
    
}
