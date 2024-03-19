using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class OneToOneCommentUser2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ccb3d47c-20aa-4b96-b441-9061d09dc5db");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e7f711bf-773a-4780-bd6c-d04c0189ed0f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "54cfd2b3-8f47-419b-ade7-cb1c518cbf79", null, "Admin", "ADMIN" },
                    { "d879c334-2131-4c5c-9ffd-0d8a52c83df9", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "ccb3d47c-20aa-4b96-b441-9061d09dc5db", null, "User", "USER" },
                    { "e7f711bf-773a-4780-bd6c-d04c0189ed0f", null, "Admin", "ADMIN" }
                });
        }
    }
}
