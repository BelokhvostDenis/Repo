using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace endmystem.Models
{
    class Book
    {              
        public int Id { get; set; }
        public string Title { get; set; }
        public virtual ICollection<Keyword> Keywords { get; set; }
    }
}
