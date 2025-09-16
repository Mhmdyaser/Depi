using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CodeFrist.Models
{
    internal class News
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Bref { get; set; }
        public string? Desc { get; set; }
        public TimeSpan Time { get; set; }
        public DateTime Date { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }


    }
}
