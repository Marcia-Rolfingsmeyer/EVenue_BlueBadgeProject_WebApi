namespace EVenue.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEnumRoomTypeInRoomEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Room", "TypeOfRoom", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Room", "TypeOfRoom");
        }
    }
}
