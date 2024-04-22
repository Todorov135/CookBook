using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CookBook.Service.AuthAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddDbSet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "027c4f2c-9189-480e-9d2c-a5ba0bcf24e1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "359b98fe-96df-4127-b715-fdc8853e6af6", "AQAAAAIAAYagAAAAEEv+VtFAUxQ/IWCsmiSL4XL2rcnlN6BghHyJVhmF1r9OkjTk+3RUHWqXS/HXbpKLlQ==", "dff18c55-5d03-483a-9caf-1da9bd02cfc6" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "027c4f2c-9189-480e-9d2c-a5ba0bcf24e1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "449205a7-0b8c-4971-a1d5-53b0f38bce48", "AQAAAAIAAYagAAAAEBR8hGMQjLc5v3ogIlzG4AVFWZpYheATd9PMNPub/IfExGEgkhOLiQaO3hHGFMdEcA==", "5cd18bd0-2ace-40fa-a352-122cfdde10ed" });
        }
    }
}
