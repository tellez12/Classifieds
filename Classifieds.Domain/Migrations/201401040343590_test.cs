namespace Classifieds.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
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
                        Code = c.String(),
                        Symbol = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Features",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StringValue = c.String(),
                        FeatureType_Id = c.Int(),
                        Value_Id = c.Int(),
                        Item_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FeatureTypes", t => t.FeatureType_Id)
                .ForeignKey("dbo.FeatureTypeValues", t => t.Value_Id)
                .ForeignKey("dbo.Items", t => t.Item_Id)
                .Index(t => t.FeatureType_Id)
                .Index(t => t.Value_Id)
                .Index(t => t.Item_Id);
            
            CreateTable(
                "dbo.FeatureTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Required = c.Boolean(nullable: false),
                        RequiredText = c.String(),
                        ControlType = c.Int(nullable: false),
                        Order = c.Int(nullable: false),
                        SectionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sections", t => t.SectionId, cascadeDelete: true)
                .Index(t => t.SectionId);
            
            CreateTable(
                "dbo.ItemTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Order = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FeatureTypeValues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                        TypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FeatureTypes", t => t.TypeId, cascadeDelete: true)
                .Index(t => t.TypeId);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Comment = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PublishDate = c.DateTime(nullable: false),
                        LastUpdateDate = c.DateTime(nullable: false),
                        AdquiredDate = c.DateTime(nullable: false),
                        Currency_Id = c.Int(),
                        Type_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Currencies", t => t.Currency_Id)
                .ForeignKey("dbo.ItemTypes", t => t.Type_Id)
                .Index(t => t.Currency_Id)
                .Index(t => t.Type_Id);
            
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
            
            CreateTable(
                "dbo.UserProfile",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.ItemTypeFeatureTypes",
                c => new
                    {
                        ItemType_Id = c.Int(nullable: false),
                        FeatureType_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ItemType_Id, t.FeatureType_Id })
                .ForeignKey("dbo.ItemTypes", t => t.ItemType_Id, cascadeDelete: true)
                .ForeignKey("dbo.FeatureTypes", t => t.FeatureType_Id, cascadeDelete: true)
                .Index(t => t.ItemType_Id)
                .Index(t => t.FeatureType_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "Type_Id", "dbo.ItemTypes");
            DropForeignKey("dbo.Pictures", "ItemId", "dbo.Items");
            DropForeignKey("dbo.Features", "Item_Id", "dbo.Items");
            DropForeignKey("dbo.Items", "Currency_Id", "dbo.Currencies");
            DropForeignKey("dbo.Features", "Value_Id", "dbo.FeatureTypeValues");
            DropForeignKey("dbo.Features", "FeatureType_Id", "dbo.FeatureTypes");
            DropForeignKey("dbo.FeatureTypeValues", "TypeId", "dbo.FeatureTypes");
            DropForeignKey("dbo.FeatureTypes", "SectionId", "dbo.Sections");
            DropForeignKey("dbo.ItemTypeFeatureTypes", "FeatureType_Id", "dbo.FeatureTypes");
            DropForeignKey("dbo.ItemTypeFeatureTypes", "ItemType_Id", "dbo.ItemTypes");
            DropIndex("dbo.Items", new[] { "Type_Id" });
            DropIndex("dbo.Pictures", new[] { "ItemId" });
            DropIndex("dbo.Features", new[] { "Item_Id" });
            DropIndex("dbo.Items", new[] { "Currency_Id" });
            DropIndex("dbo.Features", new[] { "Value_Id" });
            DropIndex("dbo.Features", new[] { "FeatureType_Id" });
            DropIndex("dbo.FeatureTypeValues", new[] { "TypeId" });
            DropIndex("dbo.FeatureTypes", new[] { "SectionId" });
            DropIndex("dbo.ItemTypeFeatureTypes", new[] { "FeatureType_Id" });
            DropIndex("dbo.ItemTypeFeatureTypes", new[] { "ItemType_Id" });
            DropTable("dbo.ItemTypeFeatureTypes");
            DropTable("dbo.UserProfile");
            DropTable("dbo.Pictures");
            DropTable("dbo.Items");
            DropTable("dbo.FeatureTypeValues");
            DropTable("dbo.Sections");
            DropTable("dbo.ItemTypes");
            DropTable("dbo.FeatureTypes");
            DropTable("dbo.Features");
            DropTable("dbo.Currencies");
        }
    }
}
