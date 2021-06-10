namespace EVenue.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OccasionOnetoManyRoomVenue : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Room", "Occasion_OccasionId", "dbo.Occasion");
            DropForeignKey("dbo.Vendor", "Occasion_OccasionId", "dbo.Occasion");
            DropIndex("dbo.Room", new[] { "Occasion_OccasionId" });
            DropIndex("dbo.Vendor", new[] { "Occasion_OccasionId" });
            AddColumn("dbo.Occasion", "RoomId", c => c.Int(nullable: false));
            AddColumn("dbo.Occasion", "VendorId", c => c.Int(nullable: false));
            CreateIndex("dbo.Occasion", "RoomId");
            CreateIndex("dbo.Occasion", "VendorId");
            AddForeignKey("dbo.Occasion", "RoomId", "dbo.Room", "RoomId", cascadeDelete: true);
            AddForeignKey("dbo.Occasion", "VendorId", "dbo.Vendor", "VendorId", cascadeDelete: true);
            DropColumn("dbo.Room", "Occasion_OccasionId");
            DropColumn("dbo.Vendor", "Occasion_OccasionId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vendor", "Occasion_OccasionId", c => c.Int());
            AddColumn("dbo.Room", "Occasion_OccasionId", c => c.Int());
            DropForeignKey("dbo.Occasion", "VendorId", "dbo.Vendor");
            DropForeignKey("dbo.Occasion", "RoomId", "dbo.Room");
            DropIndex("dbo.Occasion", new[] { "VendorId" });
            DropIndex("dbo.Occasion", new[] { "RoomId" });
            DropColumn("dbo.Occasion", "VendorId");
            DropColumn("dbo.Occasion", "RoomId");
            CreateIndex("dbo.Vendor", "Occasion_OccasionId");
            CreateIndex("dbo.Room", "Occasion_OccasionId");
            AddForeignKey("dbo.Vendor", "Occasion_OccasionId", "dbo.Occasion", "OccasionId");
            AddForeignKey("dbo.Room", "Occasion_OccasionId", "dbo.Occasion", "OccasionId");
        }
    }
}
