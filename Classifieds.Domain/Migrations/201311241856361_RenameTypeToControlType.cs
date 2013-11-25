namespace Classifieds.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameTypeToControlType : DbMigration
    {
        public override void Up()
        {
            RenameColumn("dbo.FeatureTypes", "Type", "ControlType");
          }
        
        public override void Down()
        {
            RenameColumn("dbo.FeatureTypes", "ControlType", "Type");
        }
    }
}
