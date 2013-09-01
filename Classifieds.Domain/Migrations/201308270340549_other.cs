namespace Classifieds.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class other : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Currencies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ExchangeRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Pictures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemId = c.Int(nullable: false),
                        path = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Items", t => t.ItemId, cascadeDelete: true)
                .Index(t => t.ItemId);
            
            AddColumn("dbo.Features", "Item_Id", c => c.Int());
            AddColumn("dbo.Items", "Comment", c => c.String());
            AddColumn("dbo.Items", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Items", "PublishDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Items", "LastUpdateDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Items", "AdquiredDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Items", "Currency_Id", c => c.Int());
            AddForeignKey("dbo.Features", "Item_Id", "dbo.Items", "Id");
            AddForeignKey("dbo.Items", "Currency_Id", "dbo.Currencies", "Id");
            CreateIndex("dbo.Features", "Item_Id");
            CreateIndex("dbo.Items", "Currency_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Pictures", new[] { "ItemId" });
            DropIndex("dbo.Items", new[] { "Currency_Id" });
            DropIndex("dbo.Features", new[] { "Item_Id" });
            DropForeignKey("dbo.Pictures", "ItemId", "dbo.Items");
            DropForeignKey("dbo.Items", "Currency_Id", "dbo.Currencies");
            DropForeignKey("dbo.Features", "Item_Id", "dbo.Items");
            DropColumn("dbo.Items", "Currency_Id");
            DropColumn("dbo.Items", "AdquiredDate");
            DropColumn("dbo.Items", "LastUpdateDate");
            DropColumn("dbo.Items", "PublishDate");
            DropColumn("dbo.Items", "Price");
            DropColumn("dbo.Items", "Comment");
            DropColumn("dbo.Features", "Item_Id");
            DropTable("dbo.Pictures");
            DropTable("dbo.Currencies");
        }
    }
}
