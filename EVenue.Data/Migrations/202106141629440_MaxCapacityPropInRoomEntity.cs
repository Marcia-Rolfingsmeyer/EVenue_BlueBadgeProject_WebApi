namespace EVenue.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MaxCapacityPropInRoomEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Room", "MaxCapacity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Room", "MaxCapacity");
        }
    }
}
