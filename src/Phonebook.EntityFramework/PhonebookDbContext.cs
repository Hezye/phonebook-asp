using Microsoft.EntityFrameworkCore;
using Phonebook.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Phonebook.EntityFramework
{
    public class PhonebookDbContext : DbContext
    {
        public DbSet<PhoneEntry> PhoneEntries { get; set; }

        public PhonebookDbContext(DbContextOptions<PhonebookDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Seed Db

            modelBuilder.Entity<PhoneEntry>().HasData(
                new { PhoneNumber = "123-34242342", FirstName = "Peter", LastName = "Parker" },
                new { PhoneNumber = "34242342", FirstName = "Steve", LastName = "Rogers" },
                new { PhoneNumber = "768575685", FirstName = "Tony", LastName = "Stark" });

            #endregion
        }
    }
}
