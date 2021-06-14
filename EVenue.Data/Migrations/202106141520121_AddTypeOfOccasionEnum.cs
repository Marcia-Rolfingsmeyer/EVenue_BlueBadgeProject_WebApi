namespace EVenue.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTypeOfOccasionEnum : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Occasion", "TypeOfOccasion", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Occasion", "TypeOfOccasion");
        }
    }
}
