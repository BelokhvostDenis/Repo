namespace endmystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TableBooksKeywordsRemoved : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.BooksKeywords");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.BooksKeywords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BookId = c.Int(nullable: false),
                        KeywordId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
