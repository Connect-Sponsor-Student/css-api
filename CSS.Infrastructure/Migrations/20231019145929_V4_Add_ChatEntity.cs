using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CSS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class V4_Add_ChatEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payment_ProposalService_ProposalServiceId",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_ProposalService_Service_ServiceId",
                table: "ProposalService");

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
                name: "EntityId",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "ServiceId",
                table: "ProposalService",
                newName: "SupportTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_ProposalService_ServiceId",
                table: "ProposalService",
                newName: "IX_ProposalService_SupportTypeId");

            migrationBuilder.RenameColumn(
                name: "ProposalServiceId",
                table: "Payment",
                newName: "ProposalSupportId");

            migrationBuilder.RenameIndex(
                name: "IX_Payment_ProposalServiceId",
                table: "Payment",
                newName: "IX_Payment_ProposalSupportId");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Inboxes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_Inboxes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InboxParticipants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InboxId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_InboxParticipants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InboxParticipants_Inboxes_InboxId",
                        column: x => x.InboxId,
                        principalTable: "Inboxes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InboxParticipants_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    InboxId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_Inboxes_InboxId",
                        column: x => x.InboxId,
                        principalTable: "Inboxes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Messages_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "CreatedBy", "CreationDate", "DeleteBy", "DeletionDate", "IsDeleted", "ModificationBy", "ModificationDate", "RoleName" },
                values: new object[,]
                {
                    { new Guid("48e7af65-d5cf-4560-bf76-fba1bd5caa11"), null, new DateTime(2023, 10, 19, 21, 59, 29, 406, DateTimeKind.Local).AddTicks(8093), null, null, false, null, null, "Admin" },
                    { new Guid("926ff815-1846-4dc2-9d38-89a995e268c3"), null, new DateTime(2023, 10, 19, 21, 59, 29, 406, DateTimeKind.Local).AddTicks(8123), null, null, false, null, null, "Student" },
                    { new Guid("e8ae6817-fb79-4a64-9649-8a4a807bba28"), null, new DateTime(2023, 10, 19, 21, 59, 29, 406, DateTimeKind.Local).AddTicks(8126), null, null, false, null, null, "Sponsor" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_InboxParticipants_InboxId",
                table: "InboxParticipants",
                column: "InboxId");

            migrationBuilder.CreateIndex(
                name: "IX_InboxParticipants_UserId",
                table: "InboxParticipants",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_InboxId",
                table: "Messages",
                column: "InboxId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_UserId",
                table: "Messages",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_ProposalService_ProposalSupportId",
                table: "Payment",
                column: "ProposalSupportId",
                principalTable: "ProposalService",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProposalService_Service_SupportTypeId",
                table: "ProposalService",
                column: "SupportTypeId",
                principalTable: "Service",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payment_ProposalService_ProposalSupportId",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_ProposalService_Service_SupportTypeId",
                table: "ProposalService");

            migrationBuilder.DropTable(
                name: "InboxParticipants");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Inboxes");

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

            migrationBuilder.DropColumn(
                name: "Status",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "SupportTypeId",
                table: "ProposalService",
                newName: "ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_ProposalService_SupportTypeId",
                table: "ProposalService",
                newName: "IX_ProposalService_ServiceId");

            migrationBuilder.RenameColumn(
                name: "ProposalSupportId",
                table: "Payment",
                newName: "ProposalServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_Payment_ProposalSupportId",
                table: "Payment",
                newName: "IX_Payment_ProposalServiceId");

            migrationBuilder.AddColumn<Guid>(
                name: "EntityId",
                table: "User",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "CreatedBy", "CreationDate", "DeleteBy", "DeletionDate", "IsDeleted", "ModificationBy", "ModificationDate", "RoleName" },
                values: new object[,]
                {
                    { new Guid("2bde6f7b-b894-4a2b-9446-7710df46f446"), null, new DateTime(2023, 10, 11, 22, 58, 16, 668, DateTimeKind.Local).AddTicks(2215), null, null, false, null, null, "Sponsor" },
                    { new Guid("8d46f996-f1c5-4871-b8dc-44abf5a14087"), null, new DateTime(2023, 10, 11, 22, 58, 16, 668, DateTimeKind.Local).AddTicks(2196), null, null, false, null, null, "Admin" },
                    { new Guid("b87c243f-e17c-4d85-b871-23f1bb63da9a"), null, new DateTime(2023, 10, 11, 22, 58, 16, 668, DateTimeKind.Local).AddTicks(2212), null, null, false, null, null, "Student" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_ProposalService_ProposalServiceId",
                table: "Payment",
                column: "ProposalServiceId",
                principalTable: "ProposalService",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProposalService_Service_ServiceId",
                table: "ProposalService",
                column: "ServiceId",
                principalTable: "Service",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
