namespace SQLServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class UpdateLongitudeAndLatitudeTypes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.vehicles", "latitude", c => c.Double(nullable: false));
            AlterColumn("dbo.vehicles", "longitude", c => c.Double(nullable: false));
        }

        public override void Down()
        {

        }
    }
}
