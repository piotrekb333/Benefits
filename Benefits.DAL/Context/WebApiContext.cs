using Benefits.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benefits.DAL.Context
{
    public class WebApiContext : DbContext
    {
        public WebApiContext() : base("MainConnectionString")
        {
        }
        public DbSet<City> Cities { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientGym> ClientGyms { get; set; }
        public DbSet<ClientRestaurant> ClientRestaurants { get; set; }
        public DbSet<Gym> Gyms { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<RestaurantTypeOfKitchen> RestaurantTypeOfKitchens { get; set; }
        public DbSet<TypeOfKitchen> TypeOfKitchens { get; set; }
        public DbSet<Entities.User> Users { get; set; }

    }
}
