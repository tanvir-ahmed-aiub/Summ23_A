namespace EFCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PKFKCategoryProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "CId", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "CId");
            AddForeignKey("dbo.Products", "CId", "dbo.Categories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "CId", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "CId" });
            DropColumn("dbo.Products", "CId");
        }
    }
}
