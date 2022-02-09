using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlatPhone.DataLayer.Context
{
    public partial class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<InvoiceHeader> InvoiceHeaders { get; set; }

        public DbSet<InvoiceDetail> InvoiceDetails { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Multimedia> Multimedias { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<ContactUs> ContactUs { get; set; }

        public DbSet<Image> Images { get; set; }

        public DbSet<News> News { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<SiteConfiguration> SiteConfigurations { get; set; }

        public DbSet<ClientMenuLink> ClientMenuLinks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(e => e.Tell)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
           .HasMany(e => e.FactorDetails)
           .WithOne(e => e.Product)
           .HasForeignKey(e => e.Product_Id)
           .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<InvoiceHeader>()
                   .HasMany(e => e.InvoiceDetails)
                   .WithOne(e => e.InvoiceHeader)
                   .HasForeignKey(e => e.InvoiceHeader_Id)
                   .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
