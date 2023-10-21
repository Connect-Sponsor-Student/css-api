using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CSS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FireBaseAuthen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("48e7af65-d5cf-4560-bf76-fba1bd5caa11"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("926ff815-1846-4dc2-9d38-89a995e268c3"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("e8ae6817-fb79-4a64-9649-8a4a807bba28"));

            migrationBuilder.AddColumn<bool>(
                name: "IsFireBaseAuthen",
                table: "User",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsReddem",
                table: "User",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "IsFireBaseAuthen",
                table: "User");

            migrationBuilder.DropColumn(
                name: "IsReddem",
                table: "User");

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "CreatedBy", "CreationDate", "DeleteBy", "DeletionDate", "IsDeleted", "ModificationBy", "ModificationDate", "RoleName" },
                values: new object[,]
                {
                    { new Guid("48e7af65-d5cf-4560-bf76-fba1bd5caa11"), null, new DateTime(2023, 10, 19, 21, 59, 29, 406, DateTimeKind.Local).AddTicks(8093), null, null, false, null, null, "Admin" },
                    { new Guid("926ff815-1846-4dc2-9d38-89a995e268c3"), null, new DateTime(2023, 10, 19, 21, 59, 29, 406, DateTimeKind.Local).AddTicks(8123), null, null, false, null, null, "Student" },
                    { new Guid("e8ae6817-fb79-4a64-9649-8a4a807bba28"), null, new DateTime(2023, 10, 19, 21, 59, 29, 406, DateTimeKind.Local).AddTicks(8126), null, null, false, null, null, "Sponsor" }
                });
        }
    }
}
