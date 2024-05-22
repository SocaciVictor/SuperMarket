using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Models
{
    public class SupermarketDBContext: DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<ReceiptDetail> ReceiptDetails { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-58SD638;Database=Supermarket2024;Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ReceiptDetail>().HasOne(rd => rd.Product).WithMany().HasForeignKey(rd => rd.IdProduct);
            modelBuilder.Entity<ReceiptDetail>().HasOne(rd => rd.Receipt).WithMany(r => r.ReceiptDetails).HasForeignKey(rd => rd.ReceiptId);
            base.OnModelCreating(modelBuilder);
        }
    }
}
