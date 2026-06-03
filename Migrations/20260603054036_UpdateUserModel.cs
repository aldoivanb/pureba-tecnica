using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace testdevbackjr.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Login",
                table: "ccUsers");

            migrationBuilder.RenameColumn(
                name: "FCreate",
                table: "ccUsers",
                newName: "fCreate");

            migrationBuilder.RenameColumn(
                name: "TipoUser",
                table: "ccUsers",
                newName: "TipoUser_id");

            migrationBuilder.RenameColumn(
                name: "Id_area",
                table: "ccUsers",
                newName: "IDArea");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "fCreate",
                table: "ccUsers",
                newName: "FCreate");

            migrationBuilder.RenameColumn(
                name: "TipoUser_id",
                table: "ccUsers",
                newName: "TipoUser");

            migrationBuilder.RenameColumn(
                name: "IDArea",
                table: "ccUsers",
                newName: "Id_area");

            migrationBuilder.AddColumn<string>(
                name: "Login",
                table: "ccUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
