using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Raju_VillaAPI.Migrations
{
    /// <inheritdoc />
    public partial class addUsersToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LocalUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalUsers", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "villass",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 1, 17, 16, 26, 75, DateTimeKind.Local).AddTicks(6734));

            migrationBuilder.UpdateData(
                table: "villass",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 1, 17, 16, 26, 75, DateTimeKind.Local).AddTicks(6749));

            migrationBuilder.UpdateData(
                table: "villass",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 1, 17, 16, 26, 75, DateTimeKind.Local).AddTicks(6751));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LocalUsers");

            migrationBuilder.UpdateData(
                table: "villass",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 1, 15, 7, 42, 749, DateTimeKind.Local).AddTicks(413));

            migrationBuilder.UpdateData(
                table: "villass",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 1, 15, 7, 42, 749, DateTimeKind.Local).AddTicks(438));

            migrationBuilder.UpdateData(
                table: "villass",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 1, 15, 7, 42, 749, DateTimeKind.Local).AddTicks(442));
        }
    }
}
