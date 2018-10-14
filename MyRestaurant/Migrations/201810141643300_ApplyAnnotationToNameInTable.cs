namespace MyRestaurant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyAnnotationToNameInTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tables", "Name", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tables", "Name", c => c.String());
        }
    }
}
