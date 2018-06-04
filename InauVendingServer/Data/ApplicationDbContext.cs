using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using InauVendingServer.Models;

namespace InauVendingServer.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Product> Products
        {
            get;
            set;
        }
        public virtual DbSet<Machine> Machines
        {
            get;
            set;
        }
        public virtual DbSet<ProductMachine> ProductMachines
        {
            get;
            set;
        }
        public virtual DbSet<ProductOrder> ProductOrders
        {
            get;
            set;
        }
        public virtual DbSet<Supply> Supplies
        {
            get;
            set;
        }
        public virtual DbSet<MachineSpot> MachineSpots
        {
            get;
            set;
        }
        public virtual DbSet<Owner> Owners
        {
            get;
            set;
        }
        public virtual DbSet<MachineMaintenance> MachineMaintenances
        {
            get;
            set;
        }
        public virtual DbSet<Order> Orders
        {
            get;
            set;
        }
        public virtual DbSet<Maintenance> Maintenances
        {
            get;
            set;
        }
        public virtual DbSet<PendingCommand> PendingCommands
        {
            get;
            set;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Machine>().ToTable(@"Machine");
            builder.Entity<MachineMaintenance>().ToTable(@"MachineMaintenance");
            builder.Entity<MachineSpot>().ToTable(@"MachineSpot");
            builder.Entity<Maintenance>().ToTable(@"Maintenance");
            builder.Entity<Order>().ToTable(@"Order");
            builder.Entity<Owner>().ToTable(@"Owner");
            builder.Entity<Product>().ToTable(@"Product");
            builder.Entity<ProductMachine>().ToTable(@"ProductMachine");
            builder.Entity<ProductOrder>().ToTable(@"ProductOrder").HasKey(c => new { c.OrderId, c.ProductMachineId });
            builder.Entity<Supply>().ToTable(@"Supply");
            builder.Entity<PendingCommand>().ToTable(@"PendingCommand");
        }
    }
}
