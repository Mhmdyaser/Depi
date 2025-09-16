using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CodeFrist.Models
{
    internal class Category
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Desc { get; set; }

        public ICollection<News> News { get; set; }=new Collection<News>();

    }
}
