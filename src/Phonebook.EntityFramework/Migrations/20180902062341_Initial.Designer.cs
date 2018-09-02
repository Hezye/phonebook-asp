﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Phonebook.EntityFramework;

namespace Phonebook.EntityFramework.Migrations
{
    [DbContext(typeof(PhonebookDbContext))]
    [Migration("20180902062341_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.2-rtm-30932")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Phonebook.Core.PhoneEntry", b =>
                {
                    b.Property<string>("PhoneNumber")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName");

                    b.HasKey("PhoneNumber");

                    b.ToTable("PhoneEntries");

                    b.HasData(
                        new { PhoneNumber = "123-34242342", FirstName = "Peter", LastName = "Parker" },
                        new { PhoneNumber = "34242342", FirstName = "Steve", LastName = "Rogers" },
                        new { PhoneNumber = "768575685", FirstName = "Tony", LastName = "Stark" }
                    );
                });
#pragma warning restore 612, 618
        }
    }
}
