namespace EAD2_Repeat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedEnums : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Weathers", "WeatherCondition", c => c.String(nullable: false));
            AlterColumn("dbo.Weathers", "WindDirection", c => c.String(nullable: false));
            DropColumn("dbo.Weathers", "WindCondition");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Weathers", "WindCondition", c => c.Int(nullable: false));
            AlterColumn("dbo.Weathers", "WindDirection", c => c.Int(nullable: false));
            DropColumn("dbo.Weathers", "WeatherCondition");
        }
    }
}
