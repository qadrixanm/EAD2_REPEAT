namespace EAD2_Repeat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Weathers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CityName = c.String(nullable: false),
                        WindDirection = c.Int(nullable: false),
                        WindCondition = c.Int(nullable: false),
                        MaxTemp = c.Int(nullable: false),
                        MinTemp = c.Int(nullable: false),
                        WindSpeed = c.Int(nullable: false),
                        NextDayWeather = c.String(),
                        WeatherDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Weathers");
        }
    }
}
