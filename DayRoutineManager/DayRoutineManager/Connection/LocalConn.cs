using SQLite;
using System;
using System.IO;

namespace DayRoutineManager.Connection
{
    class LocalConn
    {
        public static SQLiteConnection get() => new SQLiteConnection(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), $"DRMLocal.db"));
    }
}
