using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CSS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class V1_SeedData_07102023 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "CreatedBy", "CreationDate", "DeleteBy", "DeletionDate", "IsDeleted", "ModificationBy", "ModificationDate", "RoleName" },
                values: new object[,]
                {
                    { new Guid("30a7e389-9090-4e57-99a4-31569911361b"), null, new DateTime(2023, 10, 7, 23, 36, 35, 616, DateTimeKind.Local).AddTicks(2408), null, null, false, null, null, "Admin" },
                    { new Guid("a804085e-6dcc-4faf-838e-3c2a1f8d9577"), null, new DateTime(2023, 10, 7, 23, 36, 35, 616, DateTimeKind.Local).AddTicks(2424), null, null, false, null, null, "Sponsor" },
                    { new Guid("fd54d165-8052-4692-9700-c439e6bd5b5d"), null, new DateTime(2023, 10, 7, 23, 36, 35, 616, DateTimeKind.Local).AddTicks(2423), null, null, false, null, null, "Student" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("30a7e389-9090-4e57-99a4-31569911361b"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("a804085e-6dcc-4faf-838e-3c2a1f8d9577"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("fd54d165-8052-4692-9700-c439e6bd5b5d"));
        }
    }
}
