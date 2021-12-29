namespace Flights_Booking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Agencies",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        NameOfAgency = c.String(),
                        Country = c.String(),
                        City = c.String(),
                        YearOfCreated = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Airplanes",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        NameOfPlane = c.String(),
                        YearOfCreated = c.Int(nullable: false),
                        Total_seats = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Flights",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        From_Location = c.String(),
                        To_Location = c.String(),
                        Deparature_Time = c.String(),
                        Arrival_Time = c.String(),
                        Duration = c.String(),
                        Total_Seats = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        agency_ID = c.Long(),
                        airplane_ID = c.Long(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Agencies", t => t.agency_ID)
                .ForeignKey("dbo.Airplanes", t => t.airplane_ID)
                .Index(t => t.agency_ID)
                .Index(t => t.airplane_ID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        dateCreated = c.DateTime(nullable: false),
                        flight_ID = c.Long(),
                        payment_ID = c.Long(),
                        reservation_ID = c.Long(),
                        Ticket_ID = c.Long(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Flights", t => t.flight_ID)
                .ForeignKey("dbo.Payments", t => t.payment_ID)
                .ForeignKey("dbo.Reservations", t => t.reservation_ID)
                .ForeignKey("dbo.Tickets", t => t.Ticket_ID)
                .Index(t => t.flight_ID)
                .Index(t => t.payment_ID)
                .Index(t => t.reservation_ID)
                .Index(t => t.Ticket_ID);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Full_Name = c.String(),
                        Card_Number = c.String(),
                        CVV2 = c.String(),
                        Month_OfValidation = c.String(),
                        Year_OfValidation = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Number_OfPassport = c.String(),
                        Number_OfPhone = c.String(),
                        Bagging_Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        dateCreated = c.DateTime(nullable: false),
                        ticketStatus = c.Int(nullable: false),
                        user_UserLockoutEnabledByDefault = c.Boolean(nullable: false),
                        user_MaxFailedAccessAttemptsBeforeLockout = c.Int(nullable: false),
                        user_DefaultAccountLockoutTimeSpan = c.Time(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "Ticket_ID", "dbo.Tickets");
            DropForeignKey("dbo.Orders", "reservation_ID", "dbo.Reservations");
            DropForeignKey("dbo.Orders", "payment_ID", "dbo.Payments");
            DropForeignKey("dbo.Orders", "flight_ID", "dbo.Flights");
            DropForeignKey("dbo.Flights", "airplane_ID", "dbo.Airplanes");
            DropForeignKey("dbo.Flights", "agency_ID", "dbo.Agencies");
            DropIndex("dbo.Orders", new[] { "Ticket_ID" });
            DropIndex("dbo.Orders", new[] { "reservation_ID" });
            DropIndex("dbo.Orders", new[] { "payment_ID" });
            DropIndex("dbo.Orders", new[] { "flight_ID" });
            DropIndex("dbo.Flights", new[] { "airplane_ID" });
            DropIndex("dbo.Flights", new[] { "agency_ID" });
            DropTable("dbo.Tickets");
            DropTable("dbo.Reservations");
            DropTable("dbo.Payments");
            DropTable("dbo.Orders");
            DropTable("dbo.Flights");
            DropTable("dbo.Airplanes");
            DropTable("dbo.Agencies");
        }
    }
}
