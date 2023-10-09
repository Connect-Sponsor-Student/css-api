using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CSS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class V3_ChangeSchema_09102023 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "ProposalSponsor");

            migrationBuilder.DropColumn(
                name: "IsDone",
                table: "ProposalSponsor");

            migrationBuilder.DropColumn(
                name: "Percentage",
                table: "ProposalSponsor");

            migrationBuilder.DropColumn(
                name: "Requirement",
                table: "Proposal");

            migrationBuilder.AddColumn<Guid>(
                name: "EntityId",
                table: "User",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "StudentNumber",
                table: "Student",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Sponsor",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Admin",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "ProposalFile",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Extension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProposalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModificationBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProposalFile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProposalFile_Proposal_ProposalId",
                        column: x => x.ProposalId,
                        principalTable: "Proposal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "CreatedBy", "CreationDate", "DeleteBy", "DeletionDate", "IsDeleted", "ModificationBy", "ModificationDate", "RoleName" },
                values: new object[,]
                {
                    { new Guid("1ad11b99-9305-449d-a2f9-7ca36e4dd3a1"), null, new DateTime(2023, 10, 9, 10, 29, 15, 948, DateTimeKind.Local).AddTicks(2207), null, null, false, null, null, "Sponsor" },
                    { new Guid("5be5ec69-91a4-4236-bce3-4c1a98b99b01"), null, new DateTime(2023, 10, 9, 10, 29, 15, 948, DateTimeKind.Local).AddTicks(2206), null, null, false, null, null, "Student" },
                    { new Guid("e09157c5-aee4-4dca-8cab-92a1e6cded5f"), null, new DateTime(2023, 10, 9, 10, 29, 15, 948, DateTimeKind.Local).AddTicks(2180), null, null, false, null, null, "Admin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProposalFile_ProposalId",
                table: "ProposalFile",
                column: "ProposalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProposalFile");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("1ad11b99-9305-449d-a2f9-7ca36e4dd3a1"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("5be5ec69-91a4-4236-bce3-4c1a98b99b01"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("e09157c5-aee4-4dca-8cab-92a1e6cded5f"));

            migrationBuilder.DropColumn(
                name: "EntityId",
                table: "User");

            migrationBuilder.AlterColumn<string>(
                name: "StudentNumber",
                table: "Student",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Sponsor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "ProposalSponsor",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "IsDone",
                table: "ProposalSponsor",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "Percentage",
                table: "ProposalSponsor",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<decimal>(
                name: "Requirement",
                table: "Proposal",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Admin",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
    }
}
