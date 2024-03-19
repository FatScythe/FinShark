using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class OneToOneCommentUser3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "54cfd2b3-8f47-419b-ade7-cb1c518cbf79");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d879c334-2131-4c5c-9ffd-0d8a52c83df9");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3a34c736-c4cc-4bc8-9ab4-9bcf543a9316", null, "Admin", "ADMIN" },
                    { "b8ebb440-6c59-4957-a59b-22d6fcf5b213", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3a34c736-c4cc-4bc8-9ab4-9bcf543a9316");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b8ebb440-6c59-4957-a59b-22d6fcf5b213");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "54cfd2b3-8f47-419b-ade7-cb1c518cbf79", null, "Admin", "ADMIN" },
                    { "d879c334-2131-4c5c-9ffd-0d8a52c83df9", null, "User", "USER" }
                });
        }
    }
}
