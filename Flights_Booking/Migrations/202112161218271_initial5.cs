namespace Flights_Booking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tickets", "user_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Tickets", "user_Id");
            AddForeignKey("dbo.Tickets", "user_Id", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Tickets", "user_UserLockoutEnabledByDefault");
            DropColumn("dbo.Tickets", "user_MaxFailedAccessAttemptsBeforeLockout");
            DropColumn("dbo.Tickets", "user_DefaultAccountLockoutTimeSpan");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tickets", "user_DefaultAccountLockoutTimeSpan", c => c.Time(nullable: false, precision: 7));
            AddColumn("dbo.Tickets", "user_MaxFailedAccessAttemptsBeforeLockout", c => c.Int(nullable: false));
            AddColumn("dbo.Tickets", "user_UserLockoutEnabledByDefault", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.Tickets", "user_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Tickets", new[] { "user_Id" });
            DropColumn("dbo.Tickets", "user_Id");
        }
    }
}
