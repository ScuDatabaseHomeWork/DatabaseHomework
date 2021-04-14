using Microsoft.EntityFrameworkCore.Migrations;

namespace VeritbaniDeneme.Migrations
{
    public partial class TelColumnUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Telefon",
                table: "Doktorlar",
                type: "bigint",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 15);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Telefon",
                table: "Doktorlar",
                type: "int",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldMaxLength: 15);
        }
    }
}
