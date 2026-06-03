using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace testdevbackjr.Migrations
{
    /// <inheritdoc />
    public partial class AddAreasTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ccRIACat_Areas",
                columns: table => new
                {
                    IDArea = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AreaName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusArea = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ccRIACat_Areas", x => x.IDArea);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ccUsers_IDArea",
                table: "ccUsers",
                column: "IDArea");

            migrationBuilder.AddForeignKey(
                name: "FK_ccUsers_ccRIACat_Areas_IDArea",
                table: "ccUsers",
                column: "IDArea",
                principalTable: "ccRIACat_Areas",
                principalColumn: "IDArea",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ccUsers_ccRIACat_Areas_IDArea",
                table: "ccUsers");

            migrationBuilder.DropTable(
                name: "ccRIACat_Areas");

            migrationBuilder.DropIndex(
                name: "IX_ccUsers_IDArea",
                table: "ccUsers");
        }
    }
}
