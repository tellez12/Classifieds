namespace Classifieds.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class itemType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ItemTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
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
            
            AddColumn("dbo.Items", "Type_Id", c => c.Int());
            CreateIndex("dbo.Items", "Type_Id");
            AddForeignKey("dbo.Items", "Type_Id", "dbo.ItemTypes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "Type_Id", "dbo.ItemTypes");
            DropForeignKey("dbo.ItemTypeFeatureTypes", "FeatureType_Id", "dbo.FeatureTypes");
            DropForeignKey("dbo.ItemTypeFeatureTypes", "ItemType_Id", "dbo.ItemTypes");
            DropIndex("dbo.Items", new[] { "Type_Id" });
            DropIndex("dbo.ItemTypeFeatureTypes", new[] { "FeatureType_Id" });
            DropIndex("dbo.ItemTypeFeatureTypes", new[] { "ItemType_Id" });
            DropColumn("dbo.Items", "Type_Id");
            DropTable("dbo.ItemTypeFeatureTypes");
            DropTable("dbo.ItemTypes");
        }
    }
}
