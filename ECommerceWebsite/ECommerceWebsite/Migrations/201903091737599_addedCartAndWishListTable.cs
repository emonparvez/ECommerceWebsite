namespace ECommerceWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedCartAndWishListTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        UserId = c.Long(nullable: false),
                        CartCreatedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WishLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Long(nullable: false),
                        UpdatedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Items", "Cart_Id", c => c.Long());
            AddColumn("dbo.Products", "WishList_Id", c => c.Int());
            CreateIndex("dbo.Items", "Cart_Id");
            CreateIndex("dbo.Products", "WishList_Id");
            AddForeignKey("dbo.Items", "Cart_Id", "dbo.Carts", "Id");
            AddForeignKey("dbo.Products", "WishList_Id", "dbo.WishLists", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "WishList_Id", "dbo.WishLists");
            DropForeignKey("dbo.Items", "Cart_Id", "dbo.Carts");
            DropIndex("dbo.Products", new[] { "WishList_Id" });
            DropIndex("dbo.Items", new[] { "Cart_Id" });
            DropColumn("dbo.Products", "WishList_Id");
            DropColumn("dbo.Items", "Cart_Id");
            DropTable("dbo.WishLists");
            DropTable("dbo.Carts");
        }
    }
}
