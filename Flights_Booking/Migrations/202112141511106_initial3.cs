namespace Flights_Booking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Flights", "agency_ID", "dbo.Agencies");
            DropForeignKey("dbo.Flights", "airplane_ID", "dbo.Airplanes");
            DropIndex("dbo.Flights", new[] { "agency_ID" });
            DropIndex("dbo.Flights", new[] { "airplane_ID" });
            AddColumn("dbo.Flights", "agency", c => c.String());
            AddColumn("dbo.Reservations", "classesType", c => c.Int(nullable: false));
            DropColumn("dbo.Flights", "agency_ID");
            DropColumn("dbo.Flights", "airplane_ID");
            DropTable("dbo.Agencies");
            DropTable("dbo.Airplanes");
        }
        
        public override void Down()
        {
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
            
            AddColumn("dbo.Flights", "airplane_ID", c => c.Long());
            AddColumn("dbo.Flights", "agency_ID", c => c.Long());
            DropColumn("dbo.Reservations", "classesType");
            DropColumn("dbo.Flights", "agency");
            CreateIndex("dbo.Flights", "airplane_ID");
            CreateIndex("dbo.Flights", "agency_ID");
            AddForeignKey("dbo.Flights", "airplane_ID", "dbo.Airplanes", "ID");
            AddForeignKey("dbo.Flights", "agency_ID", "dbo.Agencies", "ID");
        }
    }
}
