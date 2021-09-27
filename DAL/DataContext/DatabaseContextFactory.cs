﻿using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;


namespace DAL.DataContext
{
    class DatabaseContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
    {
        public DatabaseContext CreateDbContext(string[] args)
        {
            AppConfiguration Settings = new AppConfiguration();

            DbContextOptionsBuilder<DatabaseContext> OptionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();

            OptionsBuilder.UseSqlServer(Settings.SqlConnectionString);

            return new DatabaseContext(OptionsBuilder.Options);
        }
    }
}
