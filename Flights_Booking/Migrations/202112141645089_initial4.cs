namespace Flights_Booking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial4 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Reservations", "Bagging_Price");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reservations", "Bagging_Price", c => c.Int(nullable: false));
        }
    }
}
