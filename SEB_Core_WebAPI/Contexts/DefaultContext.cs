using Microsoft.EntityFrameworkCore;
using SEB_Core_WebAPI.Models;

namespace SEB_Core_WebAPI.Contexts
{
    public class DefaultContext : DbContext
    {
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Bundle_Product> Bundle_Products { get; set; }
        public virtual DbSet<Bundle> Bundles { get; set; }

        public DefaultContext(DbContextOptions<DefaultContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Set up composite key
            modelBuilder.Entity<Bundle_Product>().HasKey(bp => new { bp.Bundle_BundleId, bp.Product_ProductId });
        }
    }
}
