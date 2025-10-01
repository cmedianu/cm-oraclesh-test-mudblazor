using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Data.Entities;

namespace Data.Context
{
    public class AppDbContext : DbContext
    {
        private readonly IConfiguration? _configuration;

        public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration? configuration = null) : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Set default schema from configuration, fallback to "SH" if not configured
            var defaultSchema = _configuration?["DatabaseSettings:DefaultSchema"] ?? "SH";
            modelBuilder.HasDefaultSchema(defaultSchema);
            // Customer -> Country
            modelBuilder.Entity<Customer>()
                .HasOne(c => c.Country)
                .WithMany(cn => cn.Customers)
                .HasForeignKey(c => c.CountryId);

            // Customer -> Sales
            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Sales)
                .WithOne(s => s.Customer)
                .HasForeignKey(s => s.CustId);

            // Sale composite key
            modelBuilder.Entity<Sale>()
                .HasKey(s => new { s.ProdId, s.CustId, s.TimeId, s.ChannelId, s.PromoId });
        }
    }
} 