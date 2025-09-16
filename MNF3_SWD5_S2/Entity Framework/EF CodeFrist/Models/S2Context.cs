using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EF_CodeFrist.Models
{
    internal class S2Context: DbContext
    {
        public DbSet<Category> Categorys { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=MHMD-YASER;Database=EF_Code_Frist;Trusted_Connection=True;Trust Server Certificate=True;");
        }
    }
}
