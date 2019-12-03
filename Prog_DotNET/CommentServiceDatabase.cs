using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog_DotNET
{
   public class CommentServiceDatabase : ICommentService
    {
        public void AddComment(Comment comment)
        {
            using(var context = new ReversiContext())
            {
                context.Add(comment);
                context.SaveChanges();

            }
        }

        public void DeleteComment()
        {
            using (var context = new ReversiContext())
            {
                context.Database.ExecuteSqlCommand("DELETE FROM Comments");



            }
        }

        public List<Comment> GetComments()          
            
        {
            using (var context = new ReversiContext())
            {
                //context.Database.ExecuteSqlCommand("SELECT * FROM Comments");
                return (from s in context.Comments
                        orderby s.Coment
               
                        select s).ToList();
            }
        }
    }
}
