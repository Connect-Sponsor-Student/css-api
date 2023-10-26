using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CSS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class v5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "Amount",
                table: "ProposalService");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "ProposalService");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "ProposalService");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Payment");

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Service",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Approach",
                table: "Proposal",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Proposal",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EventPlace",
                table: "Proposal",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MemberDescription",
                table: "Proposal",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberParticipate",
                table: "Proposal",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "OrganizationName",
                table: "Proposal",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Others",
                table: "Proposal",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Proposal",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProposalType",
                table: "Proposal",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Reason",
                table: "Proposal",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "StartedDate",
                table: "Proposal",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "CreatedBy", "CreationDate", "DeleteBy", "DeletionDate", "IsDeleted", "ModificationBy", "ModificationDate", "RoleName" },
                values: new object[,]
                {
                    { new Guid("2354e0b0-a613-4bf7-9b06-e26606fd110b"), null, new DateTime(2023, 10, 26, 12, 52, 56, 286, DateTimeKind.Local).AddTicks(5800), null, null, false, null, null, "Admin" },
                    { new Guid("b1faf5c9-331d-463f-83c4-e61519da1503"), null, new DateTime(2023, 10, 26, 12, 52, 56, 286, DateTimeKind.Local).AddTicks(5818), null, null, false, null, null, "Student" },
                    { new Guid("f2933713-46da-49ec-b95e-33118d7c34f8"), null, new DateTime(2023, 10, 26, 12, 52, 56, 286, DateTimeKind.Local).AddTicks(5819), null, null, false, null, null, "Sponsor" }
                });

            migrationBuilder.InsertData(
                table: "Service",
                columns: new[] { "Id", "CreatedBy", "CreationDate", "DeleteBy", "DeletionDate", "Description", "IsDeleted", "ModificationBy", "ModificationDate", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("2f1fa549-f0d1-4ba0-a0fd-38f19cc7b584"), null, new DateTime(2023, 10, 26, 12, 52, 56, 286, DateTimeKind.Local).AddTicks(5975), null, null, "Admin support", false, null, null, "FeedbackService", 150000.0 },
                    { new Guid("4beb8b2a-5885-4d74-92d2-67fd56746259"), null, new DateTime(2023, 10, 26, 12, 52, 56, 286, DateTimeKind.Local).AddTicks(5979), null, null, "Admin support, admin find potential and suitable sponsor for proposal", false, null, null, "FullService", 450000.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("2354e0b0-a613-4bf7-9b06-e26606fd110b"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("b1faf5c9-331d-463f-83c4-e61519da1503"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("f2933713-46da-49ec-b95e-33118d7c34f8"));

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("2f1fa549-f0d1-4ba0-a0fd-38f19cc7b584"));

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("4beb8b2a-5885-4d74-92d2-67fd56746259"));

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Service");

            migrationBuilder.DropColumn(
                name: "Approach",
                table: "Proposal");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Proposal");

            migrationBuilder.DropColumn(
                name: "EventPlace",
                table: "Proposal");

            migrationBuilder.DropColumn(
                name: "MemberDescription",
                table: "Proposal");

            migrationBuilder.DropColumn(
                name: "NumberParticipate",
                table: "Proposal");

            migrationBuilder.DropColumn(
                name: "OrganizationName",
                table: "Proposal");

            migrationBuilder.DropColumn(
                name: "Others",
                table: "Proposal");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Proposal");

            migrationBuilder.DropColumn(
                name: "ProposalType",
                table: "Proposal");

            migrationBuilder.DropColumn(
                name: "Reason",
                table: "Proposal");

            migrationBuilder.DropColumn(
                name: "StartedDate",
                table: "Proposal");

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "ProposalService",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ProposalService",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "ProposalService",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Payment",
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
    }
}
