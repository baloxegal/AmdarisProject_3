using Microsoft.EntityFrameworkCore.Migrations;

namespace AmdarisProject_3.API.Migrations
{
    public partial class _6M : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventsApplicationsUsers_AspNetUsers_ApplicationUsersId",
                table: "EventsApplicationsUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_EventsApplicationsUsers_Events_EventsId",
                table: "EventsApplicationsUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventsApplicationsUsers",
                table: "EventsApplicationsUsers");

            migrationBuilder.RenameTable(
                name: "EventsApplicationsUsers",
                newName: "EventsAuthors");

            migrationBuilder.RenameColumn(
                name: "EventsId",
                table: "EventsAuthors",
                newName: "EventsAuthorId");

            migrationBuilder.RenameColumn(
                name: "ApplicationUsersId",
                table: "EventsAuthors",
                newName: "AuthorsId");

            migrationBuilder.RenameIndex(
                name: "IX_EventsApplicationsUsers_EventsId",
                table: "EventsAuthors",
                newName: "IX_EventsAuthors_EventsAuthorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventsAuthors",
                table: "EventsAuthors",
                columns: new[] { "AuthorsId", "EventsAuthorId" });

            migrationBuilder.CreateTable(
                name: "EventsParticipants",
                columns: table => new
                {
                    EventsParticipantsId = table.Column<long>(type: "bigint", nullable: false),
                    ParticipantsId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventsParticipants", x => new { x.EventsParticipantsId, x.ParticipantsId });
                    table.ForeignKey(
                        name: "FK_EventsParticipants_AspNetUsers_ParticipantsId",
                        column: x => x.ParticipantsId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventsParticipants_Events_EventsParticipantsId",
                        column: x => x.EventsParticipantsId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventsParticipants_ParticipantsId",
                table: "EventsParticipants",
                column: "ParticipantsId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventsAuthors_AspNetUsers_AuthorsId",
                table: "EventsAuthors",
                column: "AuthorsId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventsAuthors_Events_EventsAuthorId",
                table: "EventsAuthors",
                column: "EventsAuthorId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.RenameTable(
                name: "AbstractPosts",
                newName: "Posts");

            migrationBuilder.RenameTable(
               name: "AbstractReactions",
               newName: "Reactions");            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventsAuthors_AspNetUsers_AuthorsId",
                table: "EventsAuthors");

            migrationBuilder.DropForeignKey(
                name: "FK_EventsAuthors_Events_EventsAuthorId",
                table: "EventsAuthors");

            migrationBuilder.DropTable(
                name: "EventsParticipants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventsAuthors",
                table: "EventsAuthors");

            migrationBuilder.RenameTable(
                name: "EventsAuthors",
                newName: "EventsApplicationsUsers");

            migrationBuilder.RenameColumn(
                name: "EventsAuthorId",
                table: "EventsApplicationsUsers",
                newName: "EventsId");

            migrationBuilder.RenameColumn(
                name: "AuthorsId",
                table: "EventsApplicationsUsers",
                newName: "ApplicationUsersId");

            migrationBuilder.RenameIndex(
                name: "IX_EventsAuthors_EventsAuthorId",
                table: "EventsApplicationsUsers",
                newName: "IX_EventsApplicationsUsers_EventsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventsApplicationsUsers",
                table: "EventsApplicationsUsers",
                columns: new[] { "ApplicationUsersId", "EventsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_EventsApplicationsUsers_AspNetUsers_ApplicationUsersId",
                table: "EventsApplicationsUsers",
                column: "ApplicationUsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventsApplicationsUsers_Events_EventsId",
                table: "EventsApplicationsUsers",
                column: "EventsId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
