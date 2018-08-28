using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace SQLiteDemo
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Indexed]
        public string userName { get; set; }
        public int totalGames { get; set; }
        public int lostGames { get; set; }
        public int wonGames { get; set; }
        public int incompleteGames { get; set; }
    }
}
