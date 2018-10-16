namespace MyRestaurant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateToReservationTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservations", "Date", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reservations", "Date");
        }
    }
}
