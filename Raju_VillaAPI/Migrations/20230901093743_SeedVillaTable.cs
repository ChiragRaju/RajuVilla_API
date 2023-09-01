using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Raju_VillaAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedVillaTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "villass",
                columns: new[] { "Id", "Amenity", "CreatedDate", "Details", "ImageUrl", "Name", "Occupancy", "Rate", "Sq", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "", new DateTime(2023, 9, 1, 15, 7, 42, 749, DateTimeKind.Local).AddTicks(413), "This exquisite villa is nestled along the pristine shores of Malibu, California, offering breathtaking ocean views from every room. ", "https://media.istockphoto.com/id/1177798051/photo/modern-house-with-terrace-and-a-swimming-pool.jpg?s=612x612&w=is&k=20&c=HOSI3bLneTix9-nZnGrd0TlDFAE-erolwhen6PjxBiw=", "RoyalVilla", 4, 200.0, 500, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "", new DateTime(2023, 9, 1, 15, 7, 42, 749, DateTimeKind.Local).AddTicks(438), "Located in the heart of the Tuscan countryside, this charming villa exudes old-world charm with its terracotta roof, lush vineyards, and olive groves. ", "https://media.istockphoto.com/id/1177798051/photo/modern-house-with-terrace-and-a-swimming-pool.jpg?s=612x612&w=is&k=20&c=HOSI3bLneTix9-nZnGrd0TlDFAE-erolwhen6PjxBiw=", "QueenVilla", 4, 200.0, 500, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "", new DateTime(2023, 9, 1, 15, 7, 42, 749, DateTimeKind.Local).AddTicks(442), "Situated in the prestigious Emirates Hills, this ultramodern villa boasts sleek, cutting-edge design and smart home automation.", "https://photos.homerez.com/v7/_S3-photos_/41250449/E1sXLAlrTsrlPvid26kYBnMIofmloaQRMMQP8WKea/url.jpg?h=800&optipress=2", "PrinceVilla", 4, 200.0, 500, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "villass",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "villass",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "villass",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
