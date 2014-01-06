namespace Classifieds.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Items", "PublishDate", c => c.DateTime());
            AlterColumn("dbo.Items", "LastUpdateDate", c => c.DateTime());
            AlterColumn("dbo.Items", "AdquiredDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Items", "AdquiredDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Items", "LastUpdateDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Items", "PublishDate", c => c.DateTime(nullable: false));
        }
    }
}
