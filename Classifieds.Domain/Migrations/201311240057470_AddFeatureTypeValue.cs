namespace Classifieds.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFeatureTypeValue : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Features", "Value_Id", c => c.Int());
            AddForeignKey("dbo.Features", "Value_Id", "dbo.FeatureTypeValues", "Id");
            CreateIndex("dbo.Features", "Value_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Features", new[] { "Value_Id" });
            DropForeignKey("dbo.Features", "Value_Id", "dbo.FeatureTypeValues");
            DropColumn("dbo.Features", "Value_Id");
        }
    }
}
