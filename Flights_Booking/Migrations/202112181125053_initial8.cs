namespace Flights_Booking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial8 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Orders", new[] { "Ticket_ID" });
            CreateIndex("dbo.Orders", "ticket_ID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Orders", new[] { "ticket_ID" });
            CreateIndex("dbo.Orders", "Ticket_ID");
        }
    }
}
