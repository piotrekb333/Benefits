namespace Benefits.DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Text;

    internal sealed class Configuration : DbMigrationsConfiguration<Benefits.DAL.Context.WebApiContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Benefits.DAL.Context.WebApiContext context)
        {
            context.Users.AddOrUpdate(new Entities.User
            {
                Username="Admin",
                PasswordHash= Encoding.ASCII.GetBytes("0x26E2C5ACEEFDE2A3FF864A802512EC38FE20AF2064F6CA7C5596319DAA9EB93350F7CDFE9921248E3D18F354F96D267DCE4FB34563EA7A0E9D01D05F0EE339C3"),
                PasswordSalt = Encoding.ASCII.GetBytes("0x41194746B527F9C411E36DE00D11ACCAC759401BA13944393C0F62FDDCD775CA1B7F8445021C6308BBD51F44CC402523F9683D948DDDE4B662B7790A7FD4DC1521F9CC9B50738525B376CB67BFB2C2C38D3767273DCDC8CB0E48CA167AB87BD14A08861252DB517A98C701F9C21925844EE8ABE8042ACBBCEA5410F3B05E4A01"),
                Role="Admin"
            });

            context.Cities.AddOrUpdate(new Entities.City
            {
                Name="City1"
            });
            context.Cities.AddOrUpdate(new Entities.City
            {
                Name = "City2"
            });
            context.TypeOfKitchens.AddOrUpdate(new Entities.TypeOfKitchen
            {
                Name = "Kitchen1"
            });
            context.TypeOfKitchens.AddOrUpdate(new Entities.TypeOfKitchen
            {
                Name = "Kitchen2"
            });
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
