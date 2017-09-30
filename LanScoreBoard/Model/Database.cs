using LiteDB;


namespace LanScoreBoard.Model
{
    public class Database
    {
        private static Database _Instance;

        private LiteDatabase _Database;


        public LiteDatabase LiteDatabase
            { get{return _Database;}
            }


        private Database()
        {
            _Database = new LiteDatabase(@"LanScoreboard.db");
        }

        public static Database Instance
        {
            get { return _Instance ?? (_Instance = new Database()); }
        }
    }
}
