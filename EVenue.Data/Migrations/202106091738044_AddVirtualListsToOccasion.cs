namespace EVenue.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddVirtualListsToOccasion : DbMigration
    {
        public override void Up()
        {
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
        }
    }
}
