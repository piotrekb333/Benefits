namespace Benefits.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ClientGyms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        ClientId = c.Int(nullable: false),
                        GymId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.Gyms", t => t.GymId, cascadeDelete: true)
                .Index(t => t.ClientId)
                .Index(t => t.GymId);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        IsPremium = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Gyms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        IsPersonalTrainer = c.Boolean(nullable: false),
                        IsSauna = c.Boolean(nullable: false),
                        IsDietician = c.Boolean(nullable: false),
                        CityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true)
                .Index(t => t.CityId);
            
            CreateTable(
                "dbo.ClientRestaurants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        ClientId = c.Int(nullable: false),
                        RestaurantId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.Restaurants", t => t.RestaurantId, cascadeDelete: true)
                .Index(t => t.ClientId)
                .Index(t => t.RestaurantId);
            
            CreateTable(
                "dbo.Restaurants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Rating = c.Int(nullable: false),
                        CityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true)
                .Index(t => t.CityId);
            
            CreateTable(
                "dbo.RestaurantTypeOfKitchens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TypeOfKitchenId = c.Int(nullable: false),
                        RestaurantId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Restaurants", t => t.RestaurantId, cascadeDelete: true)
                .ForeignKey("dbo.TypeOfKitchens", t => t.TypeOfKitchenId, cascadeDelete: true)
                .Index(t => t.TypeOfKitchenId)
                .Index(t => t.RestaurantId);
            
            CreateTable(
                "dbo.TypeOfKitchens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Username = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                        Token = c.String(),
                        PasswordHash = c.Binary(),
                        PasswordSalt = c.Binary(),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ClientRestaurants", "RestaurantId", "dbo.Restaurants");
            DropForeignKey("dbo.RestaurantTypeOfKitchens", "TypeOfKitchenId", "dbo.TypeOfKitchens");
            DropForeignKey("dbo.RestaurantTypeOfKitchens", "RestaurantId", "dbo.Restaurants");
            DropForeignKey("dbo.Restaurants", "CityId", "dbo.Cities");
            DropForeignKey("dbo.ClientRestaurants", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.ClientGyms", "GymId", "dbo.Gyms");
            DropForeignKey("dbo.Gyms", "CityId", "dbo.Cities");
            DropForeignKey("dbo.ClientGyms", "ClientId", "dbo.Clients");
            DropIndex("dbo.RestaurantTypeOfKitchens", new[] { "RestaurantId" });
            DropIndex("dbo.RestaurantTypeOfKitchens", new[] { "TypeOfKitchenId" });
            DropIndex("dbo.Restaurants", new[] { "CityId" });
            DropIndex("dbo.ClientRestaurants", new[] { "RestaurantId" });
            DropIndex("dbo.ClientRestaurants", new[] { "ClientId" });
            DropIndex("dbo.Gyms", new[] { "CityId" });
            DropIndex("dbo.ClientGyms", new[] { "GymId" });
            DropIndex("dbo.ClientGyms", new[] { "ClientId" });
            DropTable("dbo.Users");
            DropTable("dbo.TypeOfKitchens");
            DropTable("dbo.RestaurantTypeOfKitchens");
            DropTable("dbo.Restaurants");
            DropTable("dbo.ClientRestaurants");
            DropTable("dbo.Gyms");
            DropTable("dbo.Clients");
            DropTable("dbo.ClientGyms");
            DropTable("dbo.Cities");
        }
    }
}
