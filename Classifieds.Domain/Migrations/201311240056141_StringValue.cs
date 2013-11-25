namespace Classifieds.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StringValue : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Features", "StringValue", c => c.String());
            DropColumn("dbo.Features", "Value");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Features", "Value", c => c.String());
            DropColumn("dbo.Features", "StringValue");
        }
    }
}
