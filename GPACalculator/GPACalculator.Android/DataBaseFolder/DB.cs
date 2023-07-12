using GPACalculator.Droid.DataBaseFolder;
using SQLite;
using System.IO;
using Xamarin.Forms;
using GPACalculator.DBFolder;

[assembly: Dependency(typeof(DB))]

namespace GPACalculator.Droid.DataBaseFolder
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