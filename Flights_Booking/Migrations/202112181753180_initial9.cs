namespace Flights_Booking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial9 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Flights", "From_Location", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Flights", "From_Location", c => c.String());
        }
    }
}
