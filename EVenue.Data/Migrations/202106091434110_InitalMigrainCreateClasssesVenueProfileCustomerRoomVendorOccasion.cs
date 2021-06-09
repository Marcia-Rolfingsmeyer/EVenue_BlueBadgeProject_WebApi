namespace EVenue.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitalMigrainCreateClasssesVenueProfileCustomerRoomVendorOccasion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        CustomerFirstName = c.String(nullable: false),
                        CustomerLastName = c.String(nullable: false),
                        CustomerAddress = c.String(nullable: false),
                        CustomerPhone = c.String(nullable: false),
                        CustomerEmail = c.String(),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.Occasion",
                c => new
                    {
                        OccasionId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        OccasionName = c.String(),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        VenueProfileId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OccasionId)
                .ForeignKey("dbo.Customer", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.VenueProfile", t => t.VenueProfileId, cascadeDelete: true)
                .Index(t => t.VenueProfileId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.VenueProfile",
                c => new
                    {
                        VenueProfileId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        VenueName = c.String(nullable: false),
                        VenueContactPerson = c.String(),
                        VenuePhone = c.String(nullable: false),
                        VenueAddress = c.String(nullable: false),
                        VenueEmail = c.String(),
                    })
                .PrimaryKey(t => t.VenueProfileId);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Room",
                c => new
                    {
                        RoomId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        RoomName = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Amenities = c.String(nullable: false),
                        PricePerHour = c.Double(nullable: false),
                        BasePricePerDay = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.RoomId);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Vendor",
                c => new
                    {
                        VendorId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        VendorName = c.String(nullable: false),
                        VendorFee = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.VendorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Occasion", "VenueProfileId", "dbo.VenueProfile");
            DropForeignKey("dbo.Occasion", "CustomerId", "dbo.Customer");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Occasion", new[] { "CustomerId" });
            DropIndex("dbo.Occasion", new[] { "VenueProfileId" });
            DropTable("dbo.Vendor");
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.Room");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.VenueProfile");
            DropTable("dbo.Occasion");
            DropTable("dbo.Customer");
        }
    }
}
