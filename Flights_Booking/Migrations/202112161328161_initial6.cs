namespace Flights_Booking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial6 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tickets", "user_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Tickets", new[] { "user_Id" });
            AddColumn("dbo.Tickets", "userID", c => c.String());
            DropColumn("dbo.Tickets", "user_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tickets", "user_Id", c => c.String(maxLength: 128));
            DropColumn("dbo.Tickets", "userID");
            CreateIndex("dbo.Tickets", "user_Id");
            AddForeignKey("dbo.Tickets", "user_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
