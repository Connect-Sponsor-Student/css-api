using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CSS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddReedem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("5803fc81-085b-4720-a94c-9d883303d845"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("60202c83-6da5-4780-b6f7-10172c1a28fd"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("a5b35b3e-f995-4552-8521-221bcc812eaf"));

            migrationBuilder.AddColumn<int>(
                name: "NumberRefer",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ReddemCode",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "CreatedBy", "CreationDate", "DeleteBy", "DeletionDate", "IsDeleted", "ModificationBy", "ModificationDate", "RoleName" },
                values: new object[,]
                {
                    { new Guid("b08a298d-5e73-4c3c-b063-c7c9a62df6f1"), null, new DateTime(2023, 10, 21, 18, 27, 5, 371, DateTimeKind.Local).AddTicks(2325), null, null, false, null, null, "Admin" },
                    { new Guid("c94f8a69-690f-4e1e-9fd4-d15780d8b736"), null, new DateTime(2023, 10, 21, 18, 27, 5, 371, DateTimeKind.Local).AddTicks(2341), null, null, false, null, null, "Sponsor" },
                    { new Guid("febdba71-bece-4e7e-9f0a-8ad09e0818ce"), null, new DateTime(2023, 10, 21, 18, 27, 5, 371, DateTimeKind.Local).AddTicks(2339), null, null, false, null, null, "Student" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("b08a298d-5e73-4c3c-b063-c7c9a62df6f1"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("c94f8a69-690f-4e1e-9fd4-d15780d8b736"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("febdba71-bece-4e7e-9f0a-8ad09e0818ce"));

            migrationBuilder.DropColumn(
                name: "NumberRefer",
                table: "User");

            migrationBuilder.DropColumn(
                name: "ReddemCode",
                table: "User");

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "CreatedBy", "CreationDate", "DeleteBy", "DeletionDate", "IsDeleted", "ModificationBy", "ModificationDate", "RoleName" },
                values: new object[,]
                {
                    { new Guid("5803fc81-085b-4720-a94c-9d883303d845"), null, new DateTime(2023, 10, 20, 22, 14, 36, 215, DateTimeKind.Local).AddTicks(6525), null, null, false, null, null, "Student" },
                    { new Guid("60202c83-6da5-4780-b6f7-10172c1a28fd"), null, new DateTime(2023, 10, 20, 22, 14, 36, 215, DateTimeKind.Local).AddTicks(6526), null, null, false, null, null, "Sponsor" },
                    { new Guid("a5b35b3e-f995-4552-8521-221bcc812eaf"), null, new DateTime(2023, 10, 20, 22, 14, 36, 215, DateTimeKind.Local).AddTicks(6511), null, null, false, null, null, "Admin" }
                });
        }
    }
}
