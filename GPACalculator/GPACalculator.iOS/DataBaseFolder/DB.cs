using Foundation;
using GPACalculator.DBFolder;
using GPACalculator.iOS.DataBaseFolder;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(DB))]

namespace GPACalculator.iOS.DataBaseFolder
{
    class DB : IDB
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var folderName = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(folderName, "MySQLite.db3");
            return new SQLiteAsyncConnection(path);
        }
    }
}