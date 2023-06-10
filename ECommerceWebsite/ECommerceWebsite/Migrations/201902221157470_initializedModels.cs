namespace ECommerceWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initializedModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Catagories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CustomerOrders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TotalPrice = c.Double(nullable: false),
                        Customer_PhoneNumber = c.Long(),
                        OrderStatus_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Customer_PhoneNumber)
                .ForeignKey("dbo.OrderStatus", t => t.OrderStatus_Id)
                .Index(t => t.Customer_PhoneNumber)
                .Index(t => t.OrderStatus_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        PhoneNumber = c.Long(nullable: false, identity: true),
                        Password = c.String(),
                        UserType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.PhoneNumber)
                .ForeignKey("dbo.UserTypes", t => t.UserType_Id)
                .Index(t => t.UserType_Id);
            
            CreateTable(
                "dbo.UserTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Double(nullable: false),
                        Product_Id = c.Int(),
                        QuantityType_Id = c.Int(),
                        CustomerOrder_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Product_Id)
                .ForeignKey("dbo.QuantityTypes", t => t.QuantityType_Id)
                .ForeignKey("dbo.CustomerOrders", t => t.CustomerOrder_Id)
                .Index(t => t.Product_Id)
                .Index(t => t.QuantityType_Id)
                .Index(t => t.CustomerOrder_Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        SellingPrice = c.Double(nullable: false),
                        Quantity = c.Double(nullable: false),
                        QuantityType_Id = c.Int(),
                        SubCatagory_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.QuantityTypes", t => t.QuantityType_Id)
                .ForeignKey("dbo.SubCatagories", t => t.SubCatagory_Id)
                .Index(t => t.QuantityType_Id)
                .Index(t => t.SubCatagory_Id);
            
            CreateTable(
                "dbo.QuantityTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SubCatagories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Catagory_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Catagories", t => t.Catagory_Id)
                .Index(t => t.Catagory_Id);
            
            CreateTable(
                "dbo.OrderStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PurchaseLots",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BuyingPrice = c.Double(nullable: false),
                        Quantity = c.Double(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                        Product_Id = c.Int(),
                        QuantityType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Product_Id)
                .ForeignKey("dbo.QuantityTypes", t => t.QuantityType_Id)
                .Index(t => t.Product_Id)
                .Index(t => t.QuantityType_Id);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false),
                        CustomerOrder_Id = c.Int(),
                        DeliveryMan_PhoneNumber = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CustomerOrders", t => t.CustomerOrder_Id)
                .ForeignKey("dbo.Users", t => t.DeliveryMan_PhoneNumber)
                .Index(t => t.CustomerOrder_Id)
                .Index(t => t.DeliveryMan_PhoneNumber);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "DeliveryMan_PhoneNumber", "dbo.Users");
            DropForeignKey("dbo.Transactions", "CustomerOrder_Id", "dbo.CustomerOrders");
            DropForeignKey("dbo.PurchaseLots", "QuantityType_Id", "dbo.QuantityTypes");
            DropForeignKey("dbo.PurchaseLots", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.CustomerOrders", "OrderStatus_Id", "dbo.OrderStatus");
            DropForeignKey("dbo.Items", "CustomerOrder_Id", "dbo.CustomerOrders");
            DropForeignKey("dbo.Items", "QuantityType_Id", "dbo.QuantityTypes");
            DropForeignKey("dbo.Items", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.Products", "SubCatagory_Id", "dbo.SubCatagories");
            DropForeignKey("dbo.SubCatagories", "Catagory_Id", "dbo.Catagories");
            DropForeignKey("dbo.Products", "QuantityType_Id", "dbo.QuantityTypes");
            DropForeignKey("dbo.CustomerOrders", "Customer_PhoneNumber", "dbo.Users");
            DropForeignKey("dbo.Users", "UserType_Id", "dbo.UserTypes");
            DropIndex("dbo.Transactions", new[] { "DeliveryMan_PhoneNumber" });
            DropIndex("dbo.Transactions", new[] { "CustomerOrder_Id" });
            DropIndex("dbo.PurchaseLots", new[] { "QuantityType_Id" });
            DropIndex("dbo.PurchaseLots", new[] { "Product_Id" });
            DropIndex("dbo.SubCatagories", new[] { "Catagory_Id" });
            DropIndex("dbo.Products", new[] { "SubCatagory_Id" });
            DropIndex("dbo.Products", new[] { "QuantityType_Id" });
            DropIndex("dbo.Items", new[] { "CustomerOrder_Id" });
            DropIndex("dbo.Items", new[] { "QuantityType_Id" });
            DropIndex("dbo.Items", new[] { "Product_Id" });
            DropIndex("dbo.Users", new[] { "UserType_Id" });
            DropIndex("dbo.CustomerOrders", new[] { "OrderStatus_Id" });
            DropIndex("dbo.CustomerOrders", new[] { "Customer_PhoneNumber" });
            DropTable("dbo.Transactions");
            DropTable("dbo.PurchaseLots");
            DropTable("dbo.OrderStatus");
            DropTable("dbo.SubCatagories");
            DropTable("dbo.QuantityTypes");
            DropTable("dbo.Products");
            DropTable("dbo.Items");
            DropTable("dbo.UserTypes");
            DropTable("dbo.Users");
            DropTable("dbo.CustomerOrders");
            DropTable("dbo.Catagories");
        }
    }
}
