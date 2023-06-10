namespace ECommerceWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class identity_insert_on_user : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT Users ON");
        }
        
        public override void Down()
        {
        }
    }
}
