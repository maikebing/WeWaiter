using Microsoft.EntityFrameworkCore;
using System;

namespace WeWaiter.DataBase
{
    public class WeWaiterContext : DbContext
    {
        public WeWaiterContext(DbContextOptions<WeWaiterContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> User { get; set; }
        public DbSet<Goods> Goods { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Seller> Seller { get; set; }
        public DbSet<BuyItem> BuyItem { get; set; }
        public DbSet<Printer> Printer { get; set; }
        public DbSet<SellerInfo> SellerInfo { get; set; }
        public DbSet<Seat> Seat { get; set; }
        public DbSet<Catalog> Catalog { get; set; }
        

    }

}
