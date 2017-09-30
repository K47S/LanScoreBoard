using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using LanScoreBoard.Model;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LanScoreBoard.Controllers
{
    public class Cod2ScoreboardController : Controller
    {
        private const string _CollectionName = "Cod2Events";

        // GET: api/values
        [HttpGet]
        public IEnumerable<Cod2ScoreBoardEntry> Get()
        {
            var litedb = LiteDb.Instance;

            var col = litedb.GetCollection<Cod2Event>(_CollectionName);

            var entries = col.FindAll().Where(a => a.Game.Equals("cod2", StringComparison.OrdinalIgnoreCase));

            //TODO ScoreBoard query logic
            var scoreBoard = entries;

            return null;
        }

        // POST api/values
        [HttpPost]
        public void PostCsgo([FromBody] Cod2Event cod2Event)
        {
            var litedb = LiteDb.Instance;
            var col = litedb.GetCollection<Cod2Event>(_CollectionName);
            col.Insert(cod2Event);
        }
    }
}
