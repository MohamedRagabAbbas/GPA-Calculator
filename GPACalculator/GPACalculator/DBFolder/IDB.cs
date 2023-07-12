using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace GPACalculator.DBFolder
{
    public interface IDB
    {
        SQLiteAsyncConnection GetConnection();
    }
}
