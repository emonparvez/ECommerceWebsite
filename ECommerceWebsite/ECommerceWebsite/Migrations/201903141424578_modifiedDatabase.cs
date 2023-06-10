namespace ECommerceWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifiedDatabase : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Items", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Items", "QuantityTypeId", "dbo.QuantityTypes");
            DropForeignKey("dbo.Items", "Cart_Id", "dbo.Carts");
            DropForeignKey("dbo.Items", "CustomerOrder_Id", "dbo.CustomerOrders");
            DropIndex("dbo.Items", new[] { "ProductId" });
            DropIndex("dbo.Items", new[] { "QuantityTypeId" });
            DropIndex("dbo.Items", new[] { "Cart_Id" });
            DropIndex("dbo.Items", new[] { "CustomerOrder_Id" });
            AddColumn("dbo.Carts", "Confirm", c => c.Boolean(nullable: false));
            AddColumn("dbo.Products", "Cart_Id", c => c.Long());
            AddColumn("dbo.CustomerOrders", "CartId", c => c.Long(nullable: false));
            CreateIndex("dbo.Products", "Cart_Id");
            AddForeignKey("dbo.Products", "Cart_Id", "dbo.Carts", "Id");
            DropTable("dbo.Items");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(),
                        Quantity = c.Double(nullable: false),
                        QuantityTypeId = c.Int(),
                        Cart_Id = c.Long(),
                        CustomerOrder_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Products", "Cart_Id", "dbo.Carts");
            DropIndex("dbo.Products", new[] { "Cart_Id" });
            DropColumn("dbo.CustomerOrders", "CartId");
            DropColumn("dbo.Products", "Cart_Id");
            DropColumn("dbo.Carts", "Confirm");
            CreateIndex("dbo.Items", "CustomerOrder_Id");
            CreateIndex("dbo.Items", "Cart_Id");
            CreateIndex("dbo.Items", "QuantityTypeId");
            CreateIndex("dbo.Items", "ProductId");
            AddForeignKey("dbo.Items", "CustomerOrder_Id", "dbo.CustomerOrders", "Id");
            AddForeignKey("dbo.Items", "Cart_Id", "dbo.Carts", "Id");
            AddForeignKey("dbo.Items", "QuantityTypeId", "dbo.QuantityTypes", "Id");
            AddForeignKey("dbo.Items", "ProductId", "dbo.Products", "Id");
        }
    }
}
