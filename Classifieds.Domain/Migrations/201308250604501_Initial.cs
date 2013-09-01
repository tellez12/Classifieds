namespace Classifieds.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Features",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FeatureTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Required = c.Boolean(nullable: false),
                        RequiredText = c.String(),
                        Type = c.Int(nullable: false),
                        Order = c.Int(nullable: false),
                        Section_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sections", t => t.Section_Id)
                .Index(t => t.Section_Id);
            
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
                        Type_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FeatureTypes", t => t.Type_Id)
                .Index(t => t.Type_Id);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserProfile",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.FeatureTypeValues", new[] { "Type_Id" });
            DropIndex("dbo.FeatureTypes", new[] { "Section_Id" });
            DropForeignKey("dbo.FeatureTypeValues", "Type_Id", "dbo.FeatureTypes");
            DropForeignKey("dbo.FeatureTypes", "Section_Id", "dbo.Sections");
            DropTable("dbo.UserProfile");
            DropTable("dbo.Items");
            DropTable("dbo.FeatureTypeValues");
            DropTable("dbo.Sections");
            DropTable("dbo.FeatureTypes");
            DropTable("dbo.Features");
        }
    }
}
