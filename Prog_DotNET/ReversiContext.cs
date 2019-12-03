using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Prog_DotNET
{
    class ReversiContext : DbContext
    {
        public DbSet<Score> Scores { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Comment> Comments{ get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Reversi;Trusted_Connection=True;");
        }
    }
}

