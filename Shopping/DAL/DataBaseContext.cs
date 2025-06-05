using Microsoft.EntityFrameworkCore;
using Shopping.DAL.Entities;

namespace Shopping.DAL
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasIndex(c => c.Name).IsUnique(); 
        
            modelBuilder.Entity<State>().HasIndex("Name","CountryId").IsUnique();
        }

        #region Dbsets

        public DbSet<Country> Countries { get; set; }

        public DbSet<State> States { get; set; }


        #endregion
    }
}
