namespace MyRestaurant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddReservationTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        Name = c.String(),
                        RestaurantTableId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RestaurantTables", t => t.RestaurantTableId, cascadeDelete: true)
                .Index(t => t.RestaurantTableId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservations", "RestaurantTableId", "dbo.RestaurantTables");
            DropIndex("dbo.Reservations", new[] { "RestaurantTableId" });
            DropTable("dbo.Reservations");
        }
    }
}
