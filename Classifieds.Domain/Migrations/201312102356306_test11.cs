namespace Classifieds.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test11 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FeatureTypes", "Section_Id", "dbo.Sections");
            DropIndex("dbo.FeatureTypes", new[] { "Section_Id" });
            AlterColumn("dbo.FeatureTypes", "Section_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.FeatureTypes", "Section_Id");
            AddForeignKey("dbo.FeatureTypes", "Section_Id", "dbo.Sections", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FeatureTypes", "Section_Id", "dbo.Sections");
            DropIndex("dbo.FeatureTypes", new[] { "Section_Id" });
            AlterColumn("dbo.FeatureTypes", "Section_Id", c => c.Int());
            CreateIndex("dbo.FeatureTypes", "Section_Id");
            AddForeignKey("dbo.FeatureTypes", "Section_Id", "dbo.Sections", "Id");
        }
    }
}
