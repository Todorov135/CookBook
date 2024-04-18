using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CookBook.Service.AuthAPI.Migrations
{
    /// <inheritdoc />
    public partial class ChangeUserHashMethod : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "027c4f2c-9189-480e-9d2c-a5ba0bcf24e1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "449205a7-0b8c-4971-a1d5-53b0f38bce48", "AQAAAAIAAYagAAAAEBR8hGMQjLc5v3ogIlzG4AVFWZpYheATd9PMNPub/IfExGEgkhOLiQaO3hHGFMdEcA==", "5cd18bd0-2ace-40fa-a352-122cfdde10ed" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "027c4f2c-9189-480e-9d2c-a5ba0bcf24e1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c4941022-4418-41f0-8564-64158e7e95d7", "uEcrlSXriPvF1BXcwjoCkjQ1gOY/j4Kl9Jk+cD0nEs0=", "47b11b26-ffc2-47fb-a4df-50b21373736f" });
        }
    }
}
