﻿using System;
using System.IO;
using SQLite;
using SoporteCL.iOS.Services;
using SoporteCL.Services;

[assembly: Xamarin.Forms.Dependency(typeof(IOSSQLitePlatform))]
namespace SoporteCL.iOS.Services
{
    public class IOSSQLitePlatform : ISQLitePlatform
    {
        private string GetPath()
        {
            var dbName = "test.db";
            string personalFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libraryFolder = Path.Combine(personalFolder, "..", "Library");
            var path = Path.Combine(libraryFolder, dbName);
            return path;
        }
        public SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(GetPath());
        }
        public SQLiteAsyncConnection GetConnectionAsync()
        {
            return new SQLiteAsyncConnection(GetPath());
        }
    }
}