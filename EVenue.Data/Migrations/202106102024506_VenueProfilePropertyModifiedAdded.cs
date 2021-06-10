namespace EVenue.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VenueProfilePropertyModifiedAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VenueProfile", "ModifiedUtc", c => c.DateTimeOffset(precision: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.VenueProfile", "ModifiedUtc");
        }
    }
}
