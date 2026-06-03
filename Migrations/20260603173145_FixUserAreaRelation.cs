using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace testdevbackjr.Migrations
{
    /// <inheritdoc />
    public partial class FixUserAreaRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ccUsers_ccRIACat_Areas_IDArea",
                table: "ccUsers");

            migrationBuilder.AlterColumn<int>(
                name: "IDArea",
                table: "ccUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ccUsers_ccRIACat_Areas_IDArea",
                table: "ccUsers",
                column: "IDArea",
                principalTable: "ccRIACat_Areas",
                principalColumn: "IDArea");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ccUsers_ccRIACat_Areas_IDArea",
                table: "ccUsers");

            migrationBuilder.AlterColumn<int>(
                name: "IDArea",
                table: "ccUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ccUsers_ccRIACat_Areas_IDArea",
                table: "ccUsers",
                column: "IDArea",
                principalTable: "ccRIACat_Areas",
                principalColumn: "IDArea",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
