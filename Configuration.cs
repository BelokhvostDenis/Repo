namespace endmystem.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using endmystem.Models;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<MystemContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MystemContext context)
        {
            context.Keywords.AddOrUpdate(
                k => k.Name,
                new Keyword { 
                    Name = "������������",
                    Books = new List<Book>{
                        new Book { Title = "������������" }, 
                        new Book { Title = "������� ����������" }
                    }
                },
                new Keyword {
                    Name = "������",
                    Books = new List<Book>{
                        new Book { Title = "������������" }, 
                        new Book { Title = "������� ����������" }
                    }
                },
                new Keyword
                {
                    Name = "����������",
                    Books = new List<Book>{
                        new Book { Title = "������������" }                       
                    }
                },
                new Keyword
                {
                    Name = "�����",
                    Books = new List<Book>{
                        new Book { Title = "������ ��� ��������" }                        
                    }
                },
                new Keyword
                {
                    Name = "�������",
                    Books = new List<Book>{
                        new Book { Title = "������ ��� ��������" }                        
                    }
                },
                new Keyword
                {
                    Name = "���",
                    Books = new List<Book>{
                        new Book { Title = "������ ��� ��������" }                        
                    }
                }
            );
            /*context.Books.AddOrUpdate(
                b => b.Title,
                new Book { Title = "������������" },
                new Book { Title = "������ ��� ��������" },
                new Book { Title = "������� ����������" }
            );*/
           
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
