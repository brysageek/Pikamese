using System;
using System.IO;
using SQLite;

namespace Pikamese.Data
{
    public sealed class Database : SQLiteAsyncConnection
    {
        private static readonly Lazy<Database> PikaDatabase = new Lazy<Database>(()=> new Database());

        public static Database Default => PikaDatabase.Value;

        public Database() : base(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PikameseSqlLite.db3"))
        {
        }
    }
}
