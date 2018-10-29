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
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseUser> Instructors { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        public BaseContext()
        {
            Database.EnsureCreated();
            Database.Migrate();
            PragmaProperties();
        }

        public BaseContext(DbContextOptions options) : base(options) 
        {
            Database.EnsureCreated();
            Database.Migrate();
            PragmaProperties();
        }

        private void PragmaProperties()
        {
            using (var connection = Database.GetDbConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "PRAGMA journal_mode=WAL;";
                    command.CommandText = "PRAGMA temp_store=MEMORY;";
                    command.CommandText = "PRAGMA synchronous=OFF;";
                    command.ExecuteNonQuery();
                }
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
            modelBuilder.Entity<Grade>().ToTable(nameof(Grade));
            modelBuilder.Entity<Course>().ToTable(nameof(Course));
            modelBuilder.Entity<CourseUser>().ToTable(nameof(CourseUser));
            modelBuilder.Entity<Attendance>().ToTable(nameof(Attendance));
            modelBuilder.Entity<Enrollment>().ToTable(nameof(Enrollment));
        }
    }
}