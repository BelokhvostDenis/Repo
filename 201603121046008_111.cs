namespace endmystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _111 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.KeywordBooks", "Keyword_Id");
            CreateIndex("dbo.KeywordBooks", "Book_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.KeywordBooks", new[] { "Book_Id" });
            DropIndex("dbo.KeywordBooks", new[] { "Keyword_Id" });
        }
    }
}
