namespace Classifieds.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSectionId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FeatureTypes", "Section_Id", "dbo.Sections");
            DropIndex("dbo.FeatureTypes", new[] { "Section_Id" });
            RenameColumn(table: "dbo.FeatureTypes", name: "Section_Id", newName: "SectionId");
            AddForeignKey("dbo.FeatureTypes", "SectionId", "dbo.Sections", "Id", cascadeDelete: true);
            CreateIndex("dbo.FeatureTypes", "SectionId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.FeatureTypes", new[] { "SectionId" });
            DropForeignKey("dbo.FeatureTypes", "SectionId", "dbo.Sections");
            RenameColumn(table: "dbo.FeatureTypes", name: "SectionId", newName: "Section_Id");
            CreateIndex("dbo.FeatureTypes", "Section_Id");
            AddForeignKey("dbo.FeatureTypes", "Section_Id", "dbo.Sections", "Id");
        }
    }
}
