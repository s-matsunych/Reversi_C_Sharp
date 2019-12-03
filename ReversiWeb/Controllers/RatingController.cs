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
    public class RatingController : ControllerBase
    {
        public IRatingService ratingServise = new RatingServiceDatabase();

        [HttpGet]
        public int Get()
        {
            return ratingServise.GetRating();
        }

        [HttpPost]
        public void Post([FromBody]Rating rating)
        {
            ratingServise.AddRating(rating);

        }

    }
}