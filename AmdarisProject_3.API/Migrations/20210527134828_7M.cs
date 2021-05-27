using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AmdarisProject_3.API.Migrations
{
    public partial class _7M : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AbstractPosts_AspNetUsers_AuthorId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_AbstractReactions_AspNetUsers_AuthorId",
                table: "Reactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AbstractReactions",
                table: "Reactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AbstractPosts",
                table: "Posts");

            migrationBuilder.RenameTable(
                name: "Reactions",
                newName: "Reactions");

            migrationBuilder.RenameTable(
                name: "Posts",
                newName: "Posts");

            migrationBuilder.RenameIndex(
                name: "IX_AbstractReactions_AuthorId",
                table: "Reactions",
                newName: "IX_Reactions_AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_AbstractPosts_AuthorId",
                table: "Posts",
                newName: "IX_Posts_AuthorId");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_AspNetUsers_UserName",
                table: "AspNetUsers",
                column: "UserName");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reactions",
                table: "Reactions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Posts",
                table: "Posts",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "RelationShips",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InitiatorId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RespondentId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ModificationData = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelationShips", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RelationShips_AspNetUsers_InitiatorId",
                        column: x => x.InitiatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RelationShips_AspNetUsers_RespondentId",
                        column: x => x.RespondentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RelationShips_InitiatorId",
                table: "RelationShips",
                column: "InitiatorId");

            migrationBuilder.CreateIndex(
                name: "IX_RelationShips_RespondentId",
                table: "RelationShips",
                column: "RespondentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_AspNetUsers_AuthorId",
                table: "Posts",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reactions_AspNetUsers_AuthorId",
                table: "Reactions",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_AspNetUsers_AuthorId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Reactions_AspNetUsers_AuthorId",
                table: "Reactions");

            migrationBuilder.DropTable(
                name: "RelationShips");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_AspNetUsers_UserName",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reactions",
                table: "Reactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Posts",
                table: "Posts");

            migrationBuilder.RenameTable(
                name: "Reactions",
                newName: "AbstractReactions");

            migrationBuilder.RenameTable(
                name: "Posts",
                newName: "AbstractPosts");

            migrationBuilder.RenameIndex(
                name: "IX_Reactions_AuthorId",
                table: "AbstractReactions",
                newName: "IX_AbstractReactions_AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_AuthorId",
                table: "AbstractPosts",
                newName: "IX_AbstractPosts_AuthorId");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AbstractReactions",
                table: "AbstractReactions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AbstractPosts",
                table: "AbstractPosts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AbstractPosts_AspNetUsers_AuthorId",
                table: "AbstractPosts",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AbstractReactions_AspNetUsers_AuthorId",
                table: "AbstractReactions",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
