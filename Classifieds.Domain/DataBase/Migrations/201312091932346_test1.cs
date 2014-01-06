namespace Classifieds.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FeatureTypes", "SectionId", "dbo.Sections");
            DropIndex("dbo.FeatureTypes", new[] { "SectionId" });
            RenameColumn(table: "dbo.FeatureTypes", name: "SectionId", newName: "Section_Id");
            AlterColumn("dbo.FeatureTypes", "Section_Id", c => c.Int());
            CreateIndex("dbo.FeatureTypes", "Section_Id");
            AddForeignKey("dbo.FeatureTypes", "Section_Id", "dbo.Sections", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FeatureTypes", "Section_Id", "dbo.Sections");
            DropIndex("dbo.FeatureTypes", new[] { "Section_Id" });
            AlterColumn("dbo.FeatureTypes", "Section_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.FeatureTypes", name: "Section_Id", newName: "SectionId");
            CreateIndex("dbo.FeatureTypes", "SectionId");
            AddForeignKey("dbo.FeatureTypes", "SectionId", "dbo.Sections", "Id", cascadeDelete: true);
        }
    }
}
