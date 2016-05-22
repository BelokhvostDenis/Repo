namespace endmystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RelationBetweenBookandKeyword : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.KeywordBooks",
                c => new
                    {
                        Keyword_Id = c.Int(nullable: false),
                        Book_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Keyword_Id, t.Book_Id })
                .ForeignKey("dbo.Keywords", t => t.Keyword_Id, cascadeDelete: true)
                .ForeignKey("dbo.Books", t => t.Book_Id, cascadeDelete: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.KeywordBooks", "Book_Id", "dbo.Books");
            DropForeignKey("dbo.KeywordBooks", "Keyword_Id", "dbo.Keywords");
            DropTable("dbo.KeywordBooks");
        }
    }
}
