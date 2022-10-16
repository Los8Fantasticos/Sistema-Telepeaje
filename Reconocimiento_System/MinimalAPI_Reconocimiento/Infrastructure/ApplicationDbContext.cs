using Microsoft.EntityFrameworkCore;

using MinimalAPI_Reconocimiento.Models.ApplicationModel;

using System.Reflection;

namespace MinimalAPI_Reconocimiento.Infrastructure
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }
        protected ApplicationDbContext()
        {

        }
        public DbSet<PatenteModel>? Patente { get; set; } = null!;

        //public ApplicationDbContext()
        //{
        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("No connection string set for database.");
        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            _ = modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        

    }
}
