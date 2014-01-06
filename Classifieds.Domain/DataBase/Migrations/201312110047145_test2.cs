namespace Classifieds.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.FeatureTypes", name: "Section_Id", newName: "SectionId");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.FeatureTypes", name: "SectionId", newName: "Section_Id");
        }
    }
}
