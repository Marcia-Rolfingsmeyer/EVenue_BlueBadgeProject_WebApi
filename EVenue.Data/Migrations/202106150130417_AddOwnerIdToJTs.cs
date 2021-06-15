namespace EVenue.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOwnerIdToJTs : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerOccasion", "OwnerId", c => c.Guid(nullable: false));
            AddColumn("dbo.RoomOccasion", "OwnerId", c => c.Guid(nullable: false));
            AddColumn("dbo.VendorOccasion", "OwnerId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.VendorOccasion", "OwnerId");
            DropColumn("dbo.RoomOccasion", "OwnerId");
            DropColumn("dbo.CustomerOccasion", "OwnerId");
        }
    }
}
