using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog_DotNET
{
   public interface ICommentService
    {
        void DeleteComment();
        void AddComment(Comment comment);
        //void GetComments();
        List<Comment> GetComments();
            
    }
}
