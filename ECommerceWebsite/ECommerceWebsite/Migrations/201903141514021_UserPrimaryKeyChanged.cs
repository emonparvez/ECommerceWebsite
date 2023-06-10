namespace ECommerceWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserPrimaryKeyChanged : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CustomerOrders", "Customer_PhoneNumber", "dbo.Users");
            DropForeignKey("dbo.Transactions", "DeliveryMan_PhoneNumber", "dbo.Users");
            RenameColumn(table: "dbo.CustomerOrders", name: "Customer_PhoneNumber", newName: "Customer_Id");
            RenameColumn(table: "dbo.Transactions", name: "DeliveryMan_PhoneNumber", newName: "DeliveryMan_Id");
            RenameIndex(table: "dbo.CustomerOrders", name: "IX_Customer_PhoneNumber", newName: "IX_Customer_Id");
            RenameIndex(table: "dbo.Transactions", name: "IX_DeliveryMan_PhoneNumber", newName: "IX_DeliveryMan_Id");
            DropPrimaryKey("dbo.Users");
            DropColumn("dbo.Users", "PhoneNumber");
            AddColumn("dbo.Users", "Id", c => c.Long(nullable: false, identity: true));
            AddPrimaryKey("dbo.Users", "Id");
            AddForeignKey("dbo.CustomerOrders", "Customer_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Transactions", "DeliveryMan_Id", "dbo.Users", "Id");
            
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "PhoneNumber", c => c.Long(nullable: false));
            DropForeignKey("dbo.Transactions", "DeliveryMan_Id", "dbo.Users");
            DropForeignKey("dbo.CustomerOrders", "Customer_Id", "dbo.Users");
            DropPrimaryKey("dbo.Users");
            DropColumn("dbo.Users", "Id");
            AddPrimaryKey("dbo.Users", "PhoneNumber");
            RenameIndex(table: "dbo.Transactions", name: "IX_DeliveryMan_Id", newName: "IX_DeliveryMan_PhoneNumber");
            RenameIndex(table: "dbo.CustomerOrders", name: "IX_Customer_Id", newName: "IX_Customer_PhoneNumber");
            RenameColumn(table: "dbo.Transactions", name: "DeliveryMan_Id", newName: "DeliveryMan_PhoneNumber");
            RenameColumn(table: "dbo.CustomerOrders", name: "Customer_Id", newName: "Customer_PhoneNumber");
            AddForeignKey("dbo.Transactions", "DeliveryMan_PhoneNumber", "dbo.Users", "PhoneNumber");
            AddForeignKey("dbo.CustomerOrders", "Customer_PhoneNumber", "dbo.Users", "PhoneNumber");
        }
    }
}
