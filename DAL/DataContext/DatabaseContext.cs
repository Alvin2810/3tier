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
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Movie
            modelBuilder.Entity<Movie>().ToTable("movie");
            modelBuilder.Entity<Movie>().HasKey(m => m.Movie_ID);
            modelBuilder.Entity<Movie>().Property(m => m.Movie_ID).UseIdentityColumn(1, 1).IsRequired().HasColumnName("movie_id");
            modelBuilder.Entity<Movie>().Property(m => m.Movie_Title).IsRequired(true).HasMaxLength(100).HasColumnName("movie_title");
            modelBuilder.Entity<Movie>().Property(m => m.Movie_Year).IsRequired(true).HasMaxLength(4).HasColumnName("movie_year");
            #endregion

            #region Actor
            modelBuilder.Entity<Actor>().ToTable("actor");
            modelBuilder.Entity<Actor>().HasKey(a => a.Actor_ID);
            modelBuilder.Entity<Actor>().Property(a => a.Actor_ID).UseIdentityColumn(1, 1).IsRequired().HasColumnName("actor_id");
            modelBuilder.Entity<Actor>().Property(a => a.Actor_fname).IsRequired(true).HasMaxLength(100).HasColumnName("fname");
            modelBuilder.Entity<Actor>().Property(a => a.Actor_lname).IsRequired(true).HasMaxLength(100).HasColumnName("lname");
            modelBuilder.Entity<Actor>().Property(a => a.Actor_gender).IsRequired(true).HasMaxLength(100).HasColumnName("gender");
            #endregion

            #region Genre
            modelBuilder.Entity<Genre>().ToTable("genre");
            modelBuilder.Entity<Genre>().HasKey(g => g.Genre_ID);
            modelBuilder.Entity<Genre>().Property(g => g.Genre_ID).UseIdentityColumn(1, 1).IsRequired().HasColumnName("genre_id");
            modelBuilder.Entity<Genre>().Property(g => g.Genre_Name).IsRequired(true).HasMaxLength(100).HasColumnName("genre_name");
            #endregion
        }
    }
}
