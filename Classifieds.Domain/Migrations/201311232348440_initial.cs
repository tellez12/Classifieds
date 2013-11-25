namespace Classifieds.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Items", "PublishDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Items", "PublishDate", c => c.DateTime(nullable: false));
        }
    }
}
