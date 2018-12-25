namespace Benefits.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedtables : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GymClients", "Gym_Id", "dbo.Gyms");
            DropForeignKey("dbo.GymClients", "Client_Id", "dbo.Clients");
            DropForeignKey("dbo.RestaurantClients", "Restaurant_Id", "dbo.Restaurants");
            DropForeignKey("dbo.RestaurantClients", "Client_Id", "dbo.Clients");
            DropIndex("dbo.GymClients", new[] { "Gym_Id" });
            DropIndex("dbo.GymClients", new[] { "Client_Id" });
            DropIndex("dbo.RestaurantClients", new[] { "Restaurant_Id" });
            DropIndex("dbo.RestaurantClients", new[] { "Client_Id" });
            AddColumn("dbo.Gyms", "Client_Id", c => c.Int());
            AddColumn("dbo.Restaurants", "Client_Id", c => c.Int());
            CreateIndex("dbo.Gyms", "Client_Id");
            CreateIndex("dbo.Restaurants", "Client_Id");
            AddForeignKey("dbo.Gyms", "Client_Id", "dbo.Clients", "Id");
            AddForeignKey("dbo.Restaurants", "Client_Id", "dbo.Clients", "Id");
            DropTable("dbo.GymClients");
            DropTable("dbo.RestaurantClients");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.RestaurantClients",
                c => new
                    {
                        Restaurant_Id = c.Int(nullable: false),
                        Client_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Restaurant_Id, t.Client_Id });
            
            CreateTable(
                "dbo.GymClients",
                c => new
                    {
                        Gym_Id = c.Int(nullable: false),
                        Client_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Gym_Id, t.Client_Id });
            
            DropForeignKey("dbo.Restaurants", "Client_Id", "dbo.Clients");
            DropForeignKey("dbo.Gyms", "Client_Id", "dbo.Clients");
            DropIndex("dbo.Restaurants", new[] { "Client_Id" });
            DropIndex("dbo.Gyms", new[] { "Client_Id" });
            DropColumn("dbo.Restaurants", "Client_Id");
            DropColumn("dbo.Gyms", "Client_Id");
            CreateIndex("dbo.RestaurantClients", "Client_Id");
            CreateIndex("dbo.RestaurantClients", "Restaurant_Id");
            CreateIndex("dbo.GymClients", "Client_Id");
            CreateIndex("dbo.GymClients", "Gym_Id");
            AddForeignKey("dbo.RestaurantClients", "Client_Id", "dbo.Clients", "Id", cascadeDelete: true);
            AddForeignKey("dbo.RestaurantClients", "Restaurant_Id", "dbo.Restaurants", "Id", cascadeDelete: true);
            AddForeignKey("dbo.GymClients", "Client_Id", "dbo.Clients", "Id", cascadeDelete: true);
            AddForeignKey("dbo.GymClients", "Gym_Id", "dbo.Gyms", "Id", cascadeDelete: true);
        }
    }
}
