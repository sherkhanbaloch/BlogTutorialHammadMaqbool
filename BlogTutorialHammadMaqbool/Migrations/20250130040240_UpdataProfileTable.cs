using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogTutorialHammadMaqbool.Migrations
{
    /// <inheritdoc />
    public partial class UpdataProfileTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Tbl_Profile",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Tbl_Profile",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Tbl_Profile");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Tbl_Profile");
        }
    }
}
