namespace MyRestaurant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameRestaurantTableToTable : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.RestaurantTables", newName: "Tables");
            RenameColumn(table: "dbo.Reservations", name: "RestaurantTableId", newName: "TableId");
            RenameIndex(table: "dbo.Reservations", name: "IX_RestaurantTableId", newName: "IX_TableId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Reservations", name: "IX_TableId", newName: "IX_RestaurantTableId");
            RenameColumn(table: "dbo.Reservations", name: "TableId", newName: "RestaurantTableId");
            RenameTable(name: "dbo.Tables", newName: "RestaurantTables");
        }
    }
}
