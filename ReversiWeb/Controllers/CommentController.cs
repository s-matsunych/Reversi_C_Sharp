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
    public class CommentController : ControllerBase
    {
        private ICommentService commentServise = new CommentServiceDatabase();

        /*[HttpGet]
        public IEnumerable<Comment> Get()
        {
            return commentServise.GetComments();
        }*/

        [HttpGet]
        public IEnumerable<Comment> Get()
        {
          return commentServise.GetComments();
        }

        [HttpPost]
        public void Post([FromBody]Comment comment)
        {
            commentServise.AddComment(comment);
        }

    }
}