using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog_DotNET
{
    [Serializable]
    public class Comment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Coment { get; set; }

        public Comment(string Name, string Coment)
        {
            this.Name = Name;
            this.Coment = Coment;
        }
    }
}












