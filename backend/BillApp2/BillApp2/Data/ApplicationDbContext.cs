using BillApp2.Models;
using Microsoft.EntityFrameworkCore;

namespace BillApp2.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Kurumsal> Kurumsal { get; set; }
        public DbSet<Bireysel> Bireysel{ get; set; }
        public DbSet<Fatura> Fatura { get; set; }
        public DbSet<Odeme> OdenmisFatura { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Bireysel>().ToTable("Bireysel");
        }
    }
}
