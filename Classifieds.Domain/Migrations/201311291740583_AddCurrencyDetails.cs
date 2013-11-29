namespace Classifieds.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCurrencyDetails : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Currencies", "Code", c => c.String());
            AddColumn("dbo.Currencies", "Symbol", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Currencies", "Symbol");
            DropColumn("dbo.Currencies", "Code");
        }
    }
}
