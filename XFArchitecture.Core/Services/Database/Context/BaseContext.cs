using System;
using System.IO;

using Xamarin.Essentials;
using Microsoft.EntityFrameworkCore;

using XFArchitecture.Core.Models;
using XFArchitecture.Core.Utilities;

namespace XFArchitecture.Core.Services.Database.Context
{
    public class BaseContext : DbContext
    {
        private string DatabasePath;

        public DbSet<User> Users { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<Student> Students { get; set; }

        public BaseContext()
        {
        }

        public BaseContext(DbContextOptions options) : base(options) 
        {
        }

        public static BaseContext Create()
        {
            BaseContext context = new BaseContext();
            context.Database.EnsureCreated();
            context.Database.Migrate();
            PragmaProperties(context);
            return context;
        }

        private static async void PragmaProperties(BaseContext context)
        {
            var connection = context.Database.GetDbConnection();
            await connection.OpenAsync();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "PRAGMA journal_mode=WAL;";
                command.CommandText = "PRAGMA temp_store=MEMORY;";
                command.CommandText = "PRAGMA synchronous=OFF;";
                await command.ExecuteNonQueryAsync();
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            switch (DeviceInfo.Platform)
            {
                case DeviceInfo.Platforms.iOS:
                    DatabasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "..", "Library", Constants.DatabaseName); ;
                    break;
                case DeviceInfo.Platforms.Android:
                    DatabasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), Constants.DatabaseName);
                    break;
                default:
                    throw new NotImplementedException("Platform not supported");
            }
            optionsBuilder.UseSqlite($"Filename={DatabasePath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable(nameof(User));
            modelBuilder.Entity<School>().ToTable(nameof(School));
            modelBuilder.Entity<Student>().ToTable(nameof(Student));
        }
    }
}
