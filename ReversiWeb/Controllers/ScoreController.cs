using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prog_DotNET;

namespace ReversiWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScoreController : ControllerBase
    {
        private IScoreService scoreService = new ScoreServiceDatabase();

        // GET: api/Score
        [HttpGet]
        public IEnumerable<Score> Get()
        {
            return scoreService.GetTopScores();
        }

        // POST: api/Score
        [HttpPost]
        public void Post([FromBody]Score score)
        {
            scoreService.AddScore(score);
        }
    }
}