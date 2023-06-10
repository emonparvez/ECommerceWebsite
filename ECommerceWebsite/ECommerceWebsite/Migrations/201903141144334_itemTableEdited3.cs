namespace ECommerceWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class itemTableEdited3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Items", "QuantityTypeId", "dbo.QuantityTypes");
            DropIndex("dbo.Items", new[] { "QuantityTypeId" });
            AlterColumn("dbo.Items", "QuantityTypeId", c => c.Int());
            CreateIndex("dbo.Items", "QuantityTypeId");
            AddForeignKey("dbo.Items", "QuantityTypeId", "dbo.QuantityTypes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "QuantityTypeId", "dbo.QuantityTypes");
            DropIndex("dbo.Items", new[] { "QuantityTypeId" });
            AlterColumn("dbo.Items", "QuantityTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Items", "QuantityTypeId");
            AddForeignKey("dbo.Items", "QuantityTypeId", "dbo.QuantityTypes", "Id", cascadeDelete: true);
        }
    }
}
