namespace Benefits.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tables : DbMigration
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
                "dbo.TypeOfKitchens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Restaurant_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Restaurants", t => t.Restaurant_Id)
                .Index(t => t.Restaurant_Id);
            
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
                "dbo.RestaurantTypes",
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
            
            CreateTable(
                "dbo.GymClients",
                c => new
                    {
                        Gym_Id = c.Int(nullable: false),
                        Client_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Gym_Id, t.Client_Id })
                .ForeignKey("dbo.Gyms", t => t.Gym_Id, cascadeDelete: true)
                .ForeignKey("dbo.Clients", t => t.Client_Id, cascadeDelete: true)
                .Index(t => t.Gym_Id)
                .Index(t => t.Client_Id);
            
            CreateTable(
                "dbo.RestaurantClients",
                c => new
                    {
                        Restaurant_Id = c.Int(nullable: false),
                        Client_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Restaurant_Id, t.Client_Id })
                .ForeignKey("dbo.Restaurants", t => t.Restaurant_Id, cascadeDelete: true)
                .ForeignKey("dbo.Clients", t => t.Client_Id, cascadeDelete: true)
                .Index(t => t.Restaurant_Id)
                .Index(t => t.Client_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RestaurantTypes", "TypeOfKitchenId", "dbo.TypeOfKitchens");
            DropForeignKey("dbo.RestaurantTypes", "RestaurantId", "dbo.Restaurants");
            DropForeignKey("dbo.ClientRestaurants", "RestaurantId", "dbo.Restaurants");
            DropForeignKey("dbo.ClientRestaurants", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.ClientGyms", "GymId", "dbo.Gyms");
            DropForeignKey("dbo.ClientGyms", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.TypeOfKitchens", "Restaurant_Id", "dbo.Restaurants");
            DropForeignKey("dbo.RestaurantClients", "Client_Id", "dbo.Clients");
            DropForeignKey("dbo.RestaurantClients", "Restaurant_Id", "dbo.Restaurants");
            DropForeignKey("dbo.Restaurants", "CityId", "dbo.Cities");
            DropForeignKey("dbo.GymClients", "Client_Id", "dbo.Clients");
            DropForeignKey("dbo.GymClients", "Gym_Id", "dbo.Gyms");
            DropForeignKey("dbo.Gyms", "CityId", "dbo.Cities");
            DropIndex("dbo.RestaurantClients", new[] { "Client_Id" });
            DropIndex("dbo.RestaurantClients", new[] { "Restaurant_Id" });
            DropIndex("dbo.GymClients", new[] { "Client_Id" });
            DropIndex("dbo.GymClients", new[] { "Gym_Id" });
            DropIndex("dbo.RestaurantTypes", new[] { "RestaurantId" });
            DropIndex("dbo.RestaurantTypes", new[] { "TypeOfKitchenId" });
            DropIndex("dbo.ClientRestaurants", new[] { "RestaurantId" });
            DropIndex("dbo.ClientRestaurants", new[] { "ClientId" });
            DropIndex("dbo.TypeOfKitchens", new[] { "Restaurant_Id" });
            DropIndex("dbo.Restaurants", new[] { "CityId" });
            DropIndex("dbo.Gyms", new[] { "CityId" });
            DropIndex("dbo.ClientGyms", new[] { "GymId" });
            DropIndex("dbo.ClientGyms", new[] { "ClientId" });
            DropTable("dbo.RestaurantClients");
            DropTable("dbo.GymClients");
            DropTable("dbo.Users");
            DropTable("dbo.RestaurantTypes");
            DropTable("dbo.ClientRestaurants");
            DropTable("dbo.TypeOfKitchens");
            DropTable("dbo.Restaurants");
            DropTable("dbo.Gyms");
            DropTable("dbo.Clients");
            DropTable("dbo.ClientGyms");
            DropTable("dbo.Cities");
        }
    }
}
