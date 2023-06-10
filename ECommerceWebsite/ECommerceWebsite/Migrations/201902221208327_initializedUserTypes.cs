namespace ECommerceWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initializedUserTypes : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                
                 INSERT INTO [dbo].[UserTypes] ( [Type]) VALUES ( N'Admin');
                 INSERT INTO [dbo].[UserTypes] ([Type]) VALUES ( N'Customer');
                 INSERT INTO [dbo].[UserTypes] ( [Type]) VALUES ( N'DeliveryMan');


");

           
        }
        
        public override void Down()
        {
        }
    }
}
