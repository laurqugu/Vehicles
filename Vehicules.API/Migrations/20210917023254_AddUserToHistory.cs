using Microsoft.EntityFrameworkCore.Migrations;

namespace Vehicules.API.Migrations
{
    public partial class AddUserToHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicules_VehiculeTypes_VehicleTypeid",
                table: "Vehicules");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "VehiculeTypes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "VehicleTypeid",
                table: "Vehicules",
                newName: "VehicleTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicules_VehicleTypeid",
                table: "Vehicules",
                newName: "IX_Vehicules_VehicleTypeId");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Histories",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Histories_UserId",
                table: "Histories",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Histories_AspNetUsers_UserId",
                table: "Histories",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicules_VehiculeTypes_VehicleTypeId",
                table: "Vehicules",
                column: "VehicleTypeId",
                principalTable: "VehiculeTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Histories_AspNetUsers_UserId",
                table: "Histories");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicules_VehiculeTypes_VehicleTypeId",
                table: "Vehicules");

            migrationBuilder.DropIndex(
                name: "IX_Histories_UserId",
                table: "Histories");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Histories");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "VehiculeTypes",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "VehicleTypeId",
                table: "Vehicules",
                newName: "VehicleTypeid");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicules_VehicleTypeId",
                table: "Vehicules",
                newName: "IX_Vehicules_VehicleTypeid");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicules_VehiculeTypes_VehicleTypeid",
                table: "Vehicules",
                column: "VehicleTypeid",
                principalTable: "VehiculeTypes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
