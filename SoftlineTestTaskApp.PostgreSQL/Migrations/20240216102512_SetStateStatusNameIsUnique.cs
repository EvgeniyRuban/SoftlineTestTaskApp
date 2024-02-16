using Microsoft.EntityFrameworkCore.Migrations;

namespace SoftlineTestTaskApp.PostgreSQL.Migrations
{
    public partial class SetStateStatusNameIsUnique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Statuses",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Statuses_Name",
                table: "Statuses",
                column: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Statuses_Name",
                table: "Statuses");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Statuses",
                type: "text",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
