namespace Flights_Booking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial11 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Payments", "CVV2");
            DropColumn("dbo.Payments", "Month_OfValidation");
            DropColumn("dbo.Payments", "Year_OfValidation");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Payments", "Year_OfValidation", c => c.String(nullable: false));
            AddColumn("dbo.Payments", "Month_OfValidation", c => c.String(nullable: false));
            AddColumn("dbo.Payments", "CVV2", c => c.String());
        }
    }
}
