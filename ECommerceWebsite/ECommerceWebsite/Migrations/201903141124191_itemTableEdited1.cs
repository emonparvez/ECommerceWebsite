namespace ECommerceWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class itemTableEdited1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Items", "ProductId", "dbo.Products");
            DropIndex("dbo.Items", new[] { "ProductId" });
            AlterColumn("dbo.Items", "ProductId", c => c.Int());
            CreateIndex("dbo.Items", "ProductId");
            AddForeignKey("dbo.Items", "ProductId", "dbo.Products", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "ProductId", "dbo.Products");
            DropIndex("dbo.Items", new[] { "ProductId" });
            AlterColumn("dbo.Items", "ProductId", c => c.Int(nullable: false));
            CreateIndex("dbo.Items", "ProductId");
            AddForeignKey("dbo.Items", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
        }
    }
}
