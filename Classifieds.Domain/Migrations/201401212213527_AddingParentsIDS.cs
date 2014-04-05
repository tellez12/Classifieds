namespace Classifieds.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingParentsIDS : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FeatureTypes", "ParentType_Id", "dbo.FeatureTypes");
            DropForeignKey("dbo.FeatureTypeValues", "ParentValue_Id", "dbo.FeatureTypeValues");
            DropIndex("dbo.FeatureTypes", new[] { "ParentType_Id" });
            DropIndex("dbo.FeatureTypeValues", new[] { "ParentValue_Id" });
            RenameColumn(table: "dbo.FeatureTypes", name: "ParentType_Id", newName: "ParentTypeId");
            RenameColumn(table: "dbo.FeatureTypeValues", name: "ParentValue_Id", newName: "ParentValueId");
            AlterColumn("dbo.FeatureTypes", "ParentTypeId", c => c.Int(nullable: true));
            AlterColumn("dbo.FeatureTypeValues", "ParentValueId", c => c.Int(nullable: true));
            CreateIndex("dbo.FeatureTypes", "ParentTypeId");
            CreateIndex("dbo.FeatureTypeValues", "ParentValueId");
            AddForeignKey("dbo.FeatureTypes", "ParentTypeId", "dbo.FeatureTypes", "Id");
            AddForeignKey("dbo.FeatureTypeValues", "ParentValueId", "dbo.FeatureTypeValues", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FeatureTypeValues", "ParentValueId", "dbo.FeatureTypeValues");
            DropForeignKey("dbo.FeatureTypes", "ParentTypeId", "dbo.FeatureTypes");
            DropIndex("dbo.FeatureTypeValues", new[] { "ParentValueId" });
            DropIndex("dbo.FeatureTypes", new[] { "ParentTypeId" });
            AlterColumn("dbo.FeatureTypeValues", "ParentValueId", c => c.Int());
            AlterColumn("dbo.FeatureTypes", "ParentTypeId", c => c.Int());
            RenameColumn(table: "dbo.FeatureTypeValues", name: "ParentValueId", newName: "ParentValue_Id");
            RenameColumn(table: "dbo.FeatureTypes", name: "ParentTypeId", newName: "ParentType_Id");
            CreateIndex("dbo.FeatureTypeValues", "ParentValue_Id");
            CreateIndex("dbo.FeatureTypes", "ParentType_Id");
            AddForeignKey("dbo.FeatureTypeValues", "ParentValue_Id", "dbo.FeatureTypeValues", "Id");
            AddForeignKey("dbo.FeatureTypes", "ParentType_Id", "dbo.FeatureTypes", "Id");
        }
    }
}
