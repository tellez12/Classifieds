namespace Classifieds.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingParents : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FeatureTypes", "ParentType_Id", c => c.Int());
            AddColumn("dbo.FeatureTypeValues", "ParentValue_Id", c => c.Int());
            CreateIndex("dbo.FeatureTypes", "ParentType_Id");
            CreateIndex("dbo.FeatureTypeValues", "ParentValue_Id");
            AddForeignKey("dbo.FeatureTypes", "ParentType_Id", "dbo.FeatureTypes", "Id");
            AddForeignKey("dbo.FeatureTypeValues", "ParentValue_Id", "dbo.FeatureTypeValues", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FeatureTypeValues", "ParentValue_Id", "dbo.FeatureTypeValues");
            DropForeignKey("dbo.FeatureTypes", "ParentType_Id", "dbo.FeatureTypes");
            DropIndex("dbo.FeatureTypeValues", new[] { "ParentValue_Id" });
            DropIndex("dbo.FeatureTypes", new[] { "ParentType_Id" });
            DropColumn("dbo.FeatureTypeValues", "ParentValue_Id");
            DropColumn("dbo.FeatureTypes", "ParentType_Id");
        }
    }
}
