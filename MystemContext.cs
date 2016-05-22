using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace endmystem.Models
{   
    class MystemContext : DbContext
    {
        /*public MystemContext()
            : base("Entities1") { }*/

        public DbSet<Book> Books { get; set; }
        public DbSet<Keyword> Keywords { get; set; }      
    }           
}
