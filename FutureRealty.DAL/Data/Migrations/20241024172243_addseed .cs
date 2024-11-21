using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FutureRealty.DAL.Data.Migrations
{
    /// <inheritdoc />
    public partial class addseed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AboutNumbers",
                columns: new[] { "Id", "HappyClients", "HardWorkers", "HoursOfSupport", "Projects" },
                values: new object[] { 1, 232, 15, 1463, 521 });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6d010b16-fd48-4f73-bfa1-5e93136567f0", null, "User", "USER" },
                    { "d8edd17c-64f7-4b9c-9ca7-a9cd7c603995", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "07a15673-fcb3-44ad-a27f-880b3b2a27d2", 0, null, "6af147eb-f33b-4e0c-abc9-247f707e0004", "User@comp.com", true, false, null, "USER@COMP.COM", "USER@COMP.COM", "AQAAAAIAAYagAAAAEBSkcLb5In5cBRFwRq/TXXjCiZNDO66Q3/4cgxuWNjna2BrNCsDqLqBfFKl98G3dQA==", null, false, "9e6b0b8f-3e2d-4207-8cc0-02a75f6e62cb", false, "User@comp.com" },
                    { "c53a6cb2-a650-4833-a024-bc97dfb02e61", 0, null, "f99ceba2-4b3b-419c-ab76-aa7f46d38f7c", "admin@comp.com", true, false, null, "ADMIN@COMP.COM", "ADMIN@COMP.COM", "AQAAAAIAAYagAAAAEG1tuJinXRSb1dnBPtyMyv7OK27SRXXQlN8RgYu8ZRfFCgv48A5geV3UdX7fpGBftg==", null, false, "b2e735bb-2d0f-499f-b39e-3d0a4c66bb42", false, "admin@comp.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "6d010b16-fd48-4f73-bfa1-5e93136567f0", "07a15673-fcb3-44ad-a27f-880b3b2a27d2" },
                    { "d8edd17c-64f7-4b9c-9ca7-a9cd7c603995", "c53a6cb2-a650-4833-a024-bc97dfb02e61" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AboutNumbers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6d010b16-fd48-4f73-bfa1-5e93136567f0", "07a15673-fcb3-44ad-a27f-880b3b2a27d2" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d8edd17c-64f7-4b9c-9ca7-a9cd7c603995", "c53a6cb2-a650-4833-a024-bc97dfb02e61" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6d010b16-fd48-4f73-bfa1-5e93136567f0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d8edd17c-64f7-4b9c-9ca7-a9cd7c603995");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "07a15673-fcb3-44ad-a27f-880b3b2a27d2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c53a6cb2-a650-4833-a024-bc97dfb02e61");
        }
    }
}
