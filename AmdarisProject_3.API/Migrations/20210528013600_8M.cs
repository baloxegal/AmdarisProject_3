using Microsoft.EntityFrameworkCore.Migrations;

namespace AmdarisProject_3.API.Migrations
{
    public partial class _8M : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RelationShips_AspNetUsers_InitiatorId",
                table: "RelationShips");

            migrationBuilder.DropForeignKey(
                name: "FK_RelationShips_AspNetUsers_RespondentId",
                table: "RelationShips");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RelationShips",
                table: "RelationShips");

            migrationBuilder.RenameTable(
                name: "RelationShips",
                newName: "Relationships");

            migrationBuilder.RenameColumn(
                name: "Start",
                table: "Relationships",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "ModificationData",
                table: "Relationships",
                newName: "ModifiedDate");

            migrationBuilder.RenameIndex(
                name: "IX_RelationShips_RespondentId",
                table: "Relationships",
                newName: "IX_Relationships_RespondentId");

            migrationBuilder.RenameIndex(
                name: "IX_RelationShips_InitiatorId",
                table: "Relationships",
                newName: "IX_Relationships_InitiatorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Relationships",
                table: "Relationships",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Relationships_AspNetUsers_InitiatorId",
                table: "Relationships",
                column: "InitiatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Relationships_AspNetUsers_RespondentId",
                table: "Relationships",
                column: "RespondentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Relationships_AspNetUsers_InitiatorId",
                table: "Relationships");

            migrationBuilder.DropForeignKey(
                name: "FK_Relationships_AspNetUsers_RespondentId",
                table: "Relationships");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Relationships",
                table: "Relationships");

            migrationBuilder.RenameTable(
                name: "Relationships",
                newName: "RelationShips");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "RelationShips",
                newName: "Start");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "RelationShips",
                newName: "ModificationData");

            migrationBuilder.RenameIndex(
                name: "IX_Relationships_RespondentId",
                table: "RelationShips",
                newName: "IX_RelationShips_RespondentId");

            migrationBuilder.RenameIndex(
                name: "IX_Relationships_InitiatorId",
                table: "RelationShips",
                newName: "IX_RelationShips_InitiatorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RelationShips",
                table: "RelationShips",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RelationShips_AspNetUsers_InitiatorId",
                table: "RelationShips",
                column: "InitiatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RelationShips_AspNetUsers_RespondentId",
                table: "RelationShips",
                column: "RespondentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
