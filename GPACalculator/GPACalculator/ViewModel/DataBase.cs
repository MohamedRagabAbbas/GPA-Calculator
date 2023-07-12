using GPACalculator.DBFolder;
using GPACalculator.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace GPACalculator.ViewModel
{
    class DataBase
    {
        public static SQLiteAsyncConnection list = DependencyService.Get<IDB>().GetConnection();
        public static async void create_table()
        {
            await list.CreateTableAsync<Course>();
        }
        public async static void Add(Course p)
        {
            await list.InsertAsync(p);
        }
        public async static void Delete(Course p)
        {
            await list.DeleteAsync(p);
        }
    }
}
