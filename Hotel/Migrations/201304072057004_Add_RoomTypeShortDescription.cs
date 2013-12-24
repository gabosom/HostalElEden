namespace HotelEden.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_RoomTypeShortDescription : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RoomTypes", "ShortDescription", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RoomTypes", "ShortDescription");
        }
    }
}
