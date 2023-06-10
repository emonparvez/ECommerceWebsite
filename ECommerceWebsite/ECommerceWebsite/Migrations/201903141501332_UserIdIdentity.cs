namespace ECommerceWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserIdIdentity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CustomerOrders", "Customer_PhoneNumber", "dbo.Users");
            DropForeignKey("dbo.Transactions", "DeliveryMan_PhoneNumber", "dbo.Users");
            DropPrimaryKey("dbo.Users");
            AlterColumn("dbo.Users", "PhoneNumber", c => c.Long(nullable: false, identity: true));
            AddPrimaryKey("dbo.Users", "PhoneNumber");
            AddForeignKey("dbo.CustomerOrders", "Customer_PhoneNumber", "dbo.Users", "PhoneNumber");
            AddForeignKey("dbo.Transactions", "DeliveryMan_PhoneNumber", "dbo.Users", "PhoneNumber");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "DeliveryMan_PhoneNumber", "dbo.Users");
            DropForeignKey("dbo.CustomerOrders", "Customer_PhoneNumber", "dbo.Users");
            DropPrimaryKey("dbo.Users");
            AlterColumn("dbo.Users", "PhoneNumber", c => c.Long(nullable: false));
            AddPrimaryKey("dbo.Users", "PhoneNumber");
            AddForeignKey("dbo.Transactions", "DeliveryMan_PhoneNumber", "dbo.Users", "PhoneNumber");
            AddForeignKey("dbo.CustomerOrders", "Customer_PhoneNumber", "dbo.Users", "PhoneNumber");
        }
    }
}
