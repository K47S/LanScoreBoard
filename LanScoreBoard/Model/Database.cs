using LiteDB;


namespace LanScoreBoard.Model
{
    public class LiteDb : LiteDatabase
    {
        private static LiteDb _Instance;

        private LiteDb(string connectionString) : base(connectionString)
        {
        }

        public static LiteDb Instance
        {
            get { return _Instance ?? (_Instance = new LiteDb(@"LanScoreboard.db")); }
        }
    }
}
