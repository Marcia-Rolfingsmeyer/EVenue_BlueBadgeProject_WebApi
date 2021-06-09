namespace EVenue.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GetUpdateClasses : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customer", "CreatedUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Customer", "ModifiedUtc", c => c.DateTimeOffset(precision: 7));
            AddColumn("dbo.VenueProfile", "CreatedUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Room", "Occasion_OccasionId", c => c.Int());
            AddColumn("dbo.Vendor", "Occasion_OccasionId", c => c.Int());
            CreateIndex("dbo.Room", "Occasion_OccasionId");
            CreateIndex("dbo.Vendor", "Occasion_OccasionId");
            AddForeignKey("dbo.Room", "Occasion_OccasionId", "dbo.Occasion", "OccasionId");
            AddForeignKey("dbo.Vendor", "Occasion_OccasionId", "dbo.Occasion", "OccasionId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vendor", "Occasion_OccasionId", "dbo.Occasion");
            DropForeignKey("dbo.Room", "Occasion_OccasionId", "dbo.Occasion");
            DropIndex("dbo.Vendor", new[] { "Occasion_OccasionId" });
            DropIndex("dbo.Room", new[] { "Occasion_OccasionId" });
            DropColumn("dbo.Vendor", "Occasion_OccasionId");
            DropColumn("dbo.Room", "Occasion_OccasionId");
            DropColumn("dbo.VenueProfile", "CreatedUtc");
            DropColumn("dbo.Customer", "ModifiedUtc");
            DropColumn("dbo.Customer", "CreatedUtc");
        }
    }
}
