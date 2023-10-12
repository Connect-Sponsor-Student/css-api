using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CSS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class V3_11012023 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<double>(
                name: "ActualAmount",
                table: "Proposal",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "RequireAmount",
                table: "Proposal",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "Investment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProposalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    SponsorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_Investment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Investment_Proposal_ProposalId",
                        column: x => x.ProposalId,
                        principalTable: "Proposal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Investment_Sponsor_SponsorId",
                        column: x => x.SponsorId,
                        principalTable: "Sponsor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "CreatedBy", "CreationDate", "DeleteBy", "DeletionDate", "IsDeleted", "ModificationBy", "ModificationDate", "RoleName" },
                values: new object[,]
                {
                    { new Guid("2bde6f7b-b894-4a2b-9446-7710df46f446"), null, new DateTime(2023, 10, 11, 22, 58, 16, 668, DateTimeKind.Local).AddTicks(2215), null, null, false, null, null, "Sponsor" },
                    { new Guid("8d46f996-f1c5-4871-b8dc-44abf5a14087"), null, new DateTime(2023, 10, 11, 22, 58, 16, 668, DateTimeKind.Local).AddTicks(2196), null, null, false, null, null, "Admin" },
                    { new Guid("b87c243f-e17c-4d85-b871-23f1bb63da9a"), null, new DateTime(2023, 10, 11, 22, 58, 16, 668, DateTimeKind.Local).AddTicks(2212), null, null, false, null, null, "Student" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Investment_ProposalId",
                table: "Investment",
                column: "ProposalId");

            migrationBuilder.CreateIndex(
                name: "IX_Investment_SponsorId",
                table: "Investment",
                column: "SponsorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Investment");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("2bde6f7b-b894-4a2b-9446-7710df46f446"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("8d46f996-f1c5-4871-b8dc-44abf5a14087"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("b87c243f-e17c-4d85-b871-23f1bb63da9a"));

            migrationBuilder.DropColumn(
                name: "ActualAmount",
                table: "Proposal");

            migrationBuilder.DropColumn(
                name: "RequireAmount",
                table: "Proposal");

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "CreatedBy", "CreationDate", "DeleteBy", "DeletionDate", "IsDeleted", "ModificationBy", "ModificationDate", "RoleName" },
                values: new object[,]
                {
                    { new Guid("1ad11b99-9305-449d-a2f9-7ca36e4dd3a1"), null, new DateTime(2023, 10, 9, 10, 29, 15, 948, DateTimeKind.Local).AddTicks(2207), null, null, false, null, null, "Sponsor" },
                    { new Guid("5be5ec69-91a4-4236-bce3-4c1a98b99b01"), null, new DateTime(2023, 10, 9, 10, 29, 15, 948, DateTimeKind.Local).AddTicks(2206), null, null, false, null, null, "Student" },
                    { new Guid("e09157c5-aee4-4dca-8cab-92a1e6cded5f"), null, new DateTime(2023, 10, 9, 10, 29, 15, 948, DateTimeKind.Local).AddTicks(2180), null, null, false, null, null, "Admin" }
                });
        }
    }
}
