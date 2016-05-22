using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace endmystem.Models
{
    class Keyword
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }

}
