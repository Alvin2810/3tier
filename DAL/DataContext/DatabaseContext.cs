using Microsoft.EntityFrameworkCore;
using System;
using DAL.Entities;

namespace DAL.DataContext
{
    public class DatabaseContext:DbContext
    {
        public class OptionsBuild
        {

            public OptionsBuild()
            {
                Settings = new AppConfiguration();

                OptionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();

                OptionsBuilder.UseSqlServer(Settings.SqlConnectionString);

                DatabaseOptions = OptionsBuilder.Options;
            }

            public DbContextOptionsBuilder<DatabaseContext> OptionsBuilder { get; set; }

            public DbContextOptions<DatabaseContext> DatabaseOptions { get; set; }
            private  AppConfiguration Settings { get; set; }

        }

        public static OptionsBuild Options = new  OptionsBuild();

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Movie
            modelBuilder.Entity<Movie>().ToTable("movie");
            modelBuilder.Entity<Movie>().HasKey(ap => ap.Movie_ID);
            modelBuilder.Entity<Movie>().Property(ap => ap.Movie_ID).UseIdentityColumn(1, 1).IsRequired().HasColumnName("movie_id");
            modelBuilder.Entity<Movie>().Property(ap => ap.Movie_Title).IsRequired(true).HasMaxLength(100).HasColumnName("movie_title");
            modelBuilder.Entity<Movie>().Property(ap => ap.Movie_Year).IsRequired(true).HasMaxLength(4).HasColumnName("movie_year");
            #endregion

        }
    }
}
