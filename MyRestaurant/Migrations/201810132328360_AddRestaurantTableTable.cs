namespace MyRestaurant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRestaurantTableTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RestaurantTables",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        NumberOfSeats = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RestaurantTables");
        }
    }
}
