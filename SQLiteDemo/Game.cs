using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;


namespace SQLiteDemo
{
    public class Game
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Indexed]
        public string userName { get; set; }
        public string gameID { get; set; }
        public int status { get; set; }   // 0 started 1 complete
        public int whoWon { get; set; }   // team #
        public int turns { get; set; }
       
    }
}
