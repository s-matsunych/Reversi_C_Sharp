using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prog_DotNET;
using ReversiWeb.Models;

namespace ReversiWeb.Controllers
{


    public class ReversiController : Controller
    {
        IScoreService scoreService = new ScoreServiceDatabase();
        private GameState gameState;
        

        public IActionResult Index()
        {
            var field = new Field();
           // field.genrerFled();           
           
            HttpContext.Session.SetObject("field", field);
            HttpContext.Session.SetObject("s", 0);

            var model = new ReversiModel
            {s=0, Field = field, Scores = scoreService.GetTopScores() };
            return View(model);
            
        }

        public IActionResult Move(int x, int y)
        {

            
            var field = HttpContext.Session.GetObject("field") as Field;
            var s = (int)HttpContext.Session.GetObject("s");
           
           // int.TryParse(ob, out s);
            var model = new ReversiModel
            
            { Field = field, Scores = scoreService.GetTopScores(),s=s};

           
                if (field.chekUp(model.s, x, y) || field.chekDown(model.s, x, y) || field.chekLeft(model.s, x, y) || field.chekRight(model.s, x, y) ||
                field.chekLU(model.s, x, y) || field.chekLD(model.s, x, y) || field.chekRU(model.s, x, y) || field.chekRD(model.s, x, y))
                {
                    field.chekAndRevers(model.s, x, y);

                   s++;
                
                    HttpContext.Session.SetObject("field", field);
                    HttpContext.Session.SetObject("s", s);
                //return View("Index", model);
            }
                else
                {
 
                    HttpContext.Session.SetObject("field", field);
                    return View("Index", model);

                }
            
            
            //HttpContext.Session.SetObject("field", field);

            return View("Index", model);
        }
    }
}


