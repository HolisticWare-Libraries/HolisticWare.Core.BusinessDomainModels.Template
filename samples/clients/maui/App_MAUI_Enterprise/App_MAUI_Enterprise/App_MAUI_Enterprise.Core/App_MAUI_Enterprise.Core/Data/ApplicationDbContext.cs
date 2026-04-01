using Microsoft.EntityFrameworkCore;

namespace App_MAUI_Enterprise.Core
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            #region Primary Key Setup

            builder.Entity<TodoItem>().HasKey(s => s.Id);

            #endregion

            #region Configuration Setup

            builder.Entity<TodoItem>().Property(s => s.Title).HasMaxLength(255);
            builder.Entity<TodoItem>().Property(s => s.Id).ValueGeneratedOnAdd();

            #endregion
        }

        #region Table Setup

        public DbSet<TodoItem> TodoItems { get; set; }

        #endregion
    }
}