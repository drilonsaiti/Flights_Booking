namespace Flights_Booking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial10 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Flights", "To_Location", c => c.Int(nullable: false));
            AlterColumn("dbo.Flights", "Deparature_Time", c => c.String(nullable: false));
            AlterColumn("dbo.Flights", "Arrival_Time", c => c.String(nullable: false));
            AlterColumn("dbo.Flights", "agency", c => c.String(nullable: false));
            AlterColumn("dbo.Payments", "Full_Name", c => c.String(nullable: false));
            AlterColumn("dbo.Payments", "Card_Number", c => c.String(nullable: false));
            AlterColumn("dbo.Payments", "Month_OfValidation", c => c.String(nullable: false));
            AlterColumn("dbo.Payments", "Year_OfValidation", c => c.String(nullable: false));
            AlterColumn("dbo.Reservations", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Reservations", "Surname", c => c.String(nullable: false));
            AlterColumn("dbo.Reservations", "Number_OfPassport", c => c.String(nullable: false));
            AlterColumn("dbo.Reservations", "Number_OfPhone", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Reservations", "Number_OfPhone", c => c.String());
            AlterColumn("dbo.Reservations", "Number_OfPassport", c => c.String());
            AlterColumn("dbo.Reservations", "Surname", c => c.String());
            AlterColumn("dbo.Reservations", "Name", c => c.String());
            AlterColumn("dbo.Payments", "Year_OfValidation", c => c.String());
            AlterColumn("dbo.Payments", "Month_OfValidation", c => c.String());
            AlterColumn("dbo.Payments", "Card_Number", c => c.String());
            AlterColumn("dbo.Payments", "Full_Name", c => c.String());
            AlterColumn("dbo.Flights", "agency", c => c.String());
            AlterColumn("dbo.Flights", "Arrival_Time", c => c.String());
            AlterColumn("dbo.Flights", "Deparature_Time", c => c.String());
            AlterColumn("dbo.Flights", "To_Location", c => c.String());
        }
    }
}
