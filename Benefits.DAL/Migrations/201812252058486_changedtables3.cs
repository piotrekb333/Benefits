namespace Benefits.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedtables3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Gyms", "Client_Id", "dbo.Clients");
            DropForeignKey("dbo.TypeOfKitchens", "Restaurant_Id", "dbo.Restaurants");
            DropForeignKey("dbo.Restaurants", "Client_Id", "dbo.Clients");
            DropIndex("dbo.Gyms", new[] { "Client_Id" });
            DropIndex("dbo.Restaurants", new[] { "Client_Id" });
            DropIndex("dbo.TypeOfKitchens", new[] { "Restaurant_Id" });
            DropColumn("dbo.Gyms", "Client_Id");
            DropColumn("dbo.Restaurants", "Client_Id");
            DropColumn("dbo.TypeOfKitchens", "Restaurant_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TypeOfKitchens", "Restaurant_Id", c => c.Int());
            AddColumn("dbo.Restaurants", "Client_Id", c => c.Int());
            AddColumn("dbo.Gyms", "Client_Id", c => c.Int());
            CreateIndex("dbo.TypeOfKitchens", "Restaurant_Id");
            CreateIndex("dbo.Restaurants", "Client_Id");
            CreateIndex("dbo.Gyms", "Client_Id");
            AddForeignKey("dbo.Restaurants", "Client_Id", "dbo.Clients", "Id");
            AddForeignKey("dbo.TypeOfKitchens", "Restaurant_Id", "dbo.Restaurants", "Id");
            AddForeignKey("dbo.Gyms", "Client_Id", "dbo.Clients", "Id");
        }
    }
}
