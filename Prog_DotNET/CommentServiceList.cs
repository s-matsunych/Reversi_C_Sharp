using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog_DotNET
{
    public class CommentServiceList : ICommentService
    {


        private List<Comment> comments  = new List<Comment>();
        
        public CommentServiceList()
        {

        }

        public void AddComment(Comment comment)
        {
            if (comment == null)
                Console.WriteLine("Comment must be not null!");
            if (comment.Name == null)
                Console.WriteLine("Comment contains null Name!");
            if (comment.Coment.Length < 111) Console.WriteLine("The comment should be less than 110 characters");
            comments.Add(comment);
        }
        

        public void DeleteComment()
        {
            comments.Clear();
        }


        public void GetComments()
        {
            foreach(Comment comment in comments)
            {
                Console.WriteLine(comment.Name + " - " + comment.Coment);
            }
        }

        public List<Comment> GetterComent()
        {
            return comments;
        }
        internal void AddComment(Rating rating)
        {
            throw new NotImplementedException();
        }

        List<Comment> ICommentService.GetComments()
        {
            throw new NotImplementedException();
        }
    }
}
