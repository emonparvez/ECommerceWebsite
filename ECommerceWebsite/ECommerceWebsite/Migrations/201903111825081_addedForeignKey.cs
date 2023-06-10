namespace ECommerceWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedForeignKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Items", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.Items", "QuantityType_Id", "dbo.QuantityTypes");
            DropForeignKey("dbo.SubCatagories", "Catagory_Id", "dbo.Catagories");
            DropForeignKey("dbo.CustomerOrders", "OrderStatus_Id", "dbo.OrderStatus");
            DropForeignKey("dbo.Users", "UserType_Id", "dbo.UserTypes");
            DropForeignKey("dbo.PurchaseLots", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.PurchaseLots", "QuantityType_Id", "dbo.QuantityTypes");
            DropForeignKey("dbo.Transactions", "CustomerOrder_Id", "dbo.CustomerOrders");
            DropIndex("dbo.Items", new[] { "Product_Id" });
            DropIndex("dbo.Items", new[] { "QuantityType_Id" });
            DropIndex("dbo.SubCatagories", new[] { "Catagory_Id" });
            DropIndex("dbo.CustomerOrders", new[] { "OrderStatus_Id" });
            DropIndex("dbo.Users", new[] { "UserType_Id" });
            DropIndex("dbo.PurchaseLots", new[] { "Product_Id" });
            DropIndex("dbo.PurchaseLots", new[] { "QuantityType_Id" });
            DropIndex("dbo.Transactions", new[] { "CustomerOrder_Id" });
            RenameColumn(table: "dbo.Items", name: "Product_Id", newName: "ProductId");
            RenameColumn(table: "dbo.Items", name: "QuantityType_Id", newName: "QuantityTypeId");
            RenameColumn(table: "dbo.Products", name: "QuantityType_Id", newName: "QuantityTypeId");
            RenameColumn(table: "dbo.Products", name: "SubCatagory_Id", newName: "SubCatagoryId");
            RenameColumn(table: "dbo.SubCatagories", name: "Catagory_Id", newName: "CatagoryId");
            RenameColumn(table: "dbo.CustomerOrders", name: "OrderStatus_Id", newName: "OrderStatusId");
            RenameColumn(table: "dbo.Users", name: "UserType_Id", newName: "UserTypeId");
            RenameColumn(table: "dbo.PurchaseLots", name: "Product_Id", newName: "ProductId");
            RenameColumn(table: "dbo.PurchaseLots", name: "QuantityType_Id", newName: "QuantityTypeId");
            RenameColumn(table: "dbo.Transactions", name: "CustomerOrder_Id", newName: "CustomerOrderId");
            RenameIndex(table: "dbo.Products", name: "IX_SubCatagory_Id", newName: "IX_SubCatagoryId");
            RenameIndex(table: "dbo.Products", name: "IX_QuantityType_Id", newName: "IX_QuantityTypeId");
            AlterColumn("dbo.Items", "ProductId", c => c.Int(nullable: false));
            AlterColumn("dbo.Items", "QuantityTypeId", c => c.Int(nullable: false));
            AlterColumn("dbo.SubCatagories", "CatagoryId", c => c.Int(nullable: false));
            AlterColumn("dbo.CustomerOrders", "OrderStatusId", c => c.Int(nullable: false));
            AlterColumn("dbo.Users", "UserTypeId", c => c.Int(nullable: false));
            AlterColumn("dbo.PurchaseLots", "ProductId", c => c.Int(nullable: false));
            AlterColumn("dbo.PurchaseLots", "QuantityTypeId", c => c.Int(nullable: false));
            AlterColumn("dbo.Transactions", "CustomerOrderId", c => c.Int(nullable: false));
            CreateIndex("dbo.Items", "ProductId");
            CreateIndex("dbo.Items", "QuantityTypeId");
            CreateIndex("dbo.SubCatagories", "CatagoryId");
            CreateIndex("dbo.CustomerOrders", "OrderStatusId");
            CreateIndex("dbo.Users", "UserTypeId");
            CreateIndex("dbo.PurchaseLots", "ProductId");
            CreateIndex("dbo.PurchaseLots", "QuantityTypeId");
            CreateIndex("dbo.Transactions", "CustomerOrderId");
            AddForeignKey("dbo.Items", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Items", "QuantityTypeId", "dbo.QuantityTypes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.SubCatagories", "CatagoryId", "dbo.Catagories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CustomerOrders", "OrderStatusId", "dbo.OrderStatus", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Users", "UserTypeId", "dbo.UserTypes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PurchaseLots", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PurchaseLots", "QuantityTypeId", "dbo.QuantityTypes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Transactions", "CustomerOrderId", "dbo.CustomerOrders", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "CustomerOrderId", "dbo.CustomerOrders");
            DropForeignKey("dbo.PurchaseLots", "QuantityTypeId", "dbo.QuantityTypes");
            DropForeignKey("dbo.PurchaseLots", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Users", "UserTypeId", "dbo.UserTypes");
            DropForeignKey("dbo.CustomerOrders", "OrderStatusId", "dbo.OrderStatus");
            DropForeignKey("dbo.SubCatagories", "CatagoryId", "dbo.Catagories");
            DropForeignKey("dbo.Items", "QuantityTypeId", "dbo.QuantityTypes");
            DropForeignKey("dbo.Items", "ProductId", "dbo.Products");
            DropIndex("dbo.Transactions", new[] { "CustomerOrderId" });
            DropIndex("dbo.PurchaseLots", new[] { "QuantityTypeId" });
            DropIndex("dbo.PurchaseLots", new[] { "ProductId" });
            DropIndex("dbo.Users", new[] { "UserTypeId" });
            DropIndex("dbo.CustomerOrders", new[] { "OrderStatusId" });
            DropIndex("dbo.SubCatagories", new[] { "CatagoryId" });
            DropIndex("dbo.Items", new[] { "QuantityTypeId" });
            DropIndex("dbo.Items", new[] { "ProductId" });
            AlterColumn("dbo.Transactions", "CustomerOrderId", c => c.Int());
            AlterColumn("dbo.PurchaseLots", "QuantityTypeId", c => c.Int());
            AlterColumn("dbo.PurchaseLots", "ProductId", c => c.Int());
            AlterColumn("dbo.Users", "UserTypeId", c => c.Int());
            AlterColumn("dbo.CustomerOrders", "OrderStatusId", c => c.Int());
            AlterColumn("dbo.SubCatagories", "CatagoryId", c => c.Int());
            AlterColumn("dbo.Items", "QuantityTypeId", c => c.Int());
            AlterColumn("dbo.Items", "ProductId", c => c.Int());
            RenameIndex(table: "dbo.Products", name: "IX_QuantityTypeId", newName: "IX_QuantityType_Id");
            RenameIndex(table: "dbo.Products", name: "IX_SubCatagoryId", newName: "IX_SubCatagory_Id");
            RenameColumn(table: "dbo.Transactions", name: "CustomerOrderId", newName: "CustomerOrder_Id");
            RenameColumn(table: "dbo.PurchaseLots", name: "QuantityTypeId", newName: "QuantityType_Id");
            RenameColumn(table: "dbo.PurchaseLots", name: "ProductId", newName: "Product_Id");
            RenameColumn(table: "dbo.Users", name: "UserTypeId", newName: "UserType_Id");
            RenameColumn(table: "dbo.CustomerOrders", name: "OrderStatusId", newName: "OrderStatus_Id");
            RenameColumn(table: "dbo.SubCatagories", name: "CatagoryId", newName: "Catagory_Id");
            RenameColumn(table: "dbo.Products", name: "SubCatagoryId", newName: "SubCatagory_Id");
            RenameColumn(table: "dbo.Products", name: "QuantityTypeId", newName: "QuantityType_Id");
            RenameColumn(table: "dbo.Items", name: "QuantityTypeId", newName: "QuantityType_Id");
            RenameColumn(table: "dbo.Items", name: "ProductId", newName: "Product_Id");
            CreateIndex("dbo.Transactions", "CustomerOrder_Id");
            CreateIndex("dbo.PurchaseLots", "QuantityType_Id");
            CreateIndex("dbo.PurchaseLots", "Product_Id");
            CreateIndex("dbo.Users", "UserType_Id");
            CreateIndex("dbo.CustomerOrders", "OrderStatus_Id");
            CreateIndex("dbo.SubCatagories", "Catagory_Id");
            CreateIndex("dbo.Items", "QuantityType_Id");
            CreateIndex("dbo.Items", "Product_Id");
            AddForeignKey("dbo.Transactions", "CustomerOrder_Id", "dbo.CustomerOrders", "Id");
            AddForeignKey("dbo.PurchaseLots", "QuantityType_Id", "dbo.QuantityTypes", "Id");
            AddForeignKey("dbo.PurchaseLots", "Product_Id", "dbo.Products", "Id");
            AddForeignKey("dbo.Users", "UserType_Id", "dbo.UserTypes", "Id");
            AddForeignKey("dbo.CustomerOrders", "OrderStatus_Id", "dbo.OrderStatus", "Id");
            AddForeignKey("dbo.SubCatagories", "Catagory_Id", "dbo.Catagories", "Id");
            AddForeignKey("dbo.Items", "QuantityType_Id", "dbo.QuantityTypes", "Id");
            AddForeignKey("dbo.Items", "Product_Id", "dbo.Products", "Id");
        }
    }
}
