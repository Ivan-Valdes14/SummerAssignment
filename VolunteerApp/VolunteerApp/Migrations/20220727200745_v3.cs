using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VolunteerApp.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Volunteers",
                columns: new[] { "ID", "FirstName", "LastName", "Status" },
                values: new object[,]
                {
                    { 1, "Ivan", "Valdes", "Approved" },
                    { 2, "Barb", "Valdes", "Pending Approval" },
                    { 3, "Bert", "Valdes", "Disapproved" },
                    { 4, "Cook", "Valdes", "Inactive" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Volunteers",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Volunteers",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Volunteers",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Volunteers",
                keyColumn: "ID",
                keyValue: 4);
        }
    }
}
