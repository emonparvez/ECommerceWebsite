namespace ECommerceWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addAdmin : DbMigration
    {
        public override void Up()
        {
            Sql(@"
            SET IDENTITY_INSERT [dbo].[Users] ON

            INSERT INTO [dbo].[Users] ([PhoneNumber], [Password], [UserType_Id]) VALUES (01554035483, N'12341234', 4)");
        }
        
        public override void Down()
        {
        }
    }
}
