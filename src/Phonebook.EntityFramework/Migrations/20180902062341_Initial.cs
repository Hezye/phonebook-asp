using Microsoft.EntityFrameworkCore.Migrations;

namespace Phonebook.EntityFramework.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PhoneEntries",
                columns: table => new
                {
                    PhoneNumber = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneEntries", x => x.PhoneNumber);
                });

            migrationBuilder.InsertData(
                table: "PhoneEntries",
                columns: new[] { "PhoneNumber", "FirstName", "LastName" },
                values: new object[] { "123-34242342", "Peter", "Parker" });

            migrationBuilder.InsertData(
                table: "PhoneEntries",
                columns: new[] { "PhoneNumber", "FirstName", "LastName" },
                values: new object[] { "34242342", "Steve", "Rogers" });

            migrationBuilder.InsertData(
                table: "PhoneEntries",
                columns: new[] { "PhoneNumber", "FirstName", "LastName" },
                values: new object[] { "768575685", "Tony", "Stark" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhoneEntries");
        }
    }
}
