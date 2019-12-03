using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prog_DotNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog_DotNET.Tests
{
    [TestClass()]
    public class CommentServiceListTest
    {
       CommentServiceList service = new CommentServiceList();

        [TestMethod()]
        public void AddCommentTest()
        {
            service.AddComment(new Comment("Stasik", "ksdckmoic[mwcmcjkokaskomc[+cad"));
            var comments = service.GetterComent();
            Assert.AreEqual<string>("Stasik", comments[0].Name);
            Assert.AreEqual<string>("ksdckmoic[mwcmcjkokaskomc[+cad", comments[0].Coment);


        }

        [TestMethod()]
        public void DeleteCommentTest()
        {
            service.AddComment(new Comment("Stasik", "ksdckmoic[mwcmcjkokaskomc[+cad"));
            service.AddComment(new Comment("Valik", "sdfwfdfd"));
            service.AddComment(new Comment("Igor", "dddddddddddddddd"));
            service.AddComment(new Comment("Sanya", "dfwfwf"));
            service.AddComment(new Comment("Hrisha", "12423dcwf515sc///"));
            service.DeleteComment();
            Assert.AreEqual<int>(0, service.GetterComent().Count);


        }

        
    }
}