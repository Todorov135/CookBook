using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CookBook.Service.AuthAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "027c4f2c-9189-480e-9d2c-a5ba0bcf24e1", 0, "c4941022-4418-41f0-8564-64158e7e95d7", "admin@admin.com", true, "Admin", "LastAdminName", false, null, "ADMIN@ADMIN.COM", null, "uEcrlSXriPvF1BXcwjoCkjQ1gOY/j4Kl9Jk+cD0nEs0=", null, false, "47b11b26-ffc2-47fb-a4df-50b21373736f", false, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "027c4f2c-9189-480e-9d2c-a5ba0bcf24e1");
        }
    }
}
