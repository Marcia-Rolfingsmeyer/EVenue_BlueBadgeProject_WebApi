namespace EVenue.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UnknownPendingChanges : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Occasion", "Vendor_VendorId", "dbo.Vendor");
            DropIndex("dbo.Occasion", new[] { "Vendor_VendorId" });
            DropColumn("dbo.Occasion", "Vendor_VendorId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Occasion", "Vendor_VendorId", c => c.Int());
            CreateIndex("dbo.Occasion", "Vendor_VendorId");
            AddForeignKey("dbo.Occasion", "Vendor_VendorId", "dbo.Vendor", "VendorId");
        }
    }
}
