namespace EVenue.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addJointTables : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Occasion", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.Occasion", "RoomId", "dbo.Room");
            DropForeignKey("dbo.Occasion", "VendorId", "dbo.Vendor");
            DropIndex("dbo.Occasion", new[] { "CustomerId" });
            DropIndex("dbo.Occasion", new[] { "RoomId" });
            DropIndex("dbo.Occasion", new[] { "VendorId" });
            RenameColumn(table: "dbo.Occasion", name: "VendorId", newName: "Vendor_VendorId");
            CreateTable(
                "dbo.CustomerOccasion",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        OccasionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customer", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Occasion", t => t.OccasionId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.OccasionId);
            
            CreateTable(
                "dbo.RoomOccasion",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoomId = c.Int(nullable: false),
                        OccasionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Occasion", t => t.OccasionId, cascadeDelete: true)
                .ForeignKey("dbo.Room", t => t.RoomId, cascadeDelete: true)
                .Index(t => t.RoomId)
                .Index(t => t.OccasionId);
            
            CreateTable(
                "dbo.VendorOccasion",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VendorId = c.Int(nullable: false),
                        OccasionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Occasion", t => t.OccasionId, cascadeDelete: true)
                .ForeignKey("dbo.Vendor", t => t.VendorId, cascadeDelete: true)
                .Index(t => t.VendorId)
                .Index(t => t.OccasionId);
            
            AlterColumn("dbo.Occasion", "Vendor_VendorId", c => c.Int());
            CreateIndex("dbo.Occasion", "Vendor_VendorId");
            AddForeignKey("dbo.Occasion", "Vendor_VendorId", "dbo.Vendor", "VendorId");
            DropColumn("dbo.Occasion", "CustomerId");
            DropColumn("dbo.Occasion", "RoomId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Occasion", "RoomId", c => c.Int(nullable: false));
            AddColumn("dbo.Occasion", "CustomerId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Occasion", "Vendor_VendorId", "dbo.Vendor");
            DropForeignKey("dbo.VendorOccasion", "VendorId", "dbo.Vendor");
            DropForeignKey("dbo.VendorOccasion", "OccasionId", "dbo.Occasion");
            DropForeignKey("dbo.RoomOccasion", "RoomId", "dbo.Room");
            DropForeignKey("dbo.RoomOccasion", "OccasionId", "dbo.Occasion");
            DropForeignKey("dbo.CustomerOccasion", "OccasionId", "dbo.Occasion");
            DropForeignKey("dbo.CustomerOccasion", "CustomerId", "dbo.Customer");
            DropIndex("dbo.VendorOccasion", new[] { "OccasionId" });
            DropIndex("dbo.VendorOccasion", new[] { "VendorId" });
            DropIndex("dbo.RoomOccasion", new[] { "OccasionId" });
            DropIndex("dbo.RoomOccasion", new[] { "RoomId" });
            DropIndex("dbo.Occasion", new[] { "Vendor_VendorId" });
            DropIndex("dbo.CustomerOccasion", new[] { "OccasionId" });
            DropIndex("dbo.CustomerOccasion", new[] { "CustomerId" });
            AlterColumn("dbo.Occasion", "Vendor_VendorId", c => c.Int(nullable: false));
            DropTable("dbo.VendorOccasion");
            DropTable("dbo.RoomOccasion");
            DropTable("dbo.CustomerOccasion");
            RenameColumn(table: "dbo.Occasion", name: "Vendor_VendorId", newName: "VendorId");
            CreateIndex("dbo.Occasion", "VendorId");
            CreateIndex("dbo.Occasion", "RoomId");
            CreateIndex("dbo.Occasion", "CustomerId");
            AddForeignKey("dbo.Occasion", "VendorId", "dbo.Vendor", "VendorId", cascadeDelete: true);
            AddForeignKey("dbo.Occasion", "RoomId", "dbo.Room", "RoomId", cascadeDelete: true);
            AddForeignKey("dbo.Occasion", "CustomerId", "dbo.Customer", "CustomerId", cascadeDelete: true);
        }
    }
}
