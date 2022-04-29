using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfcData.Migrations
{
    public partial class ForumMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "forums",
                columns: table => new
                {
                    id = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_forums", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Role = table.Column<string>(type: "TEXT", nullable: false),
                    City = table.Column<string>(type: "TEXT", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Forumid = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_forums_Forumid",
                        column: x => x.Forumid,
                        principalTable: "forums",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "SubForum",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    OwnedById = table.Column<string>(type: "TEXT", nullable: true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Forumid = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubForum", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubForum_forums_Forumid",
                        column: x => x.Forumid,
                        principalTable: "forums",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_SubForum_Users_OwnedById",
                        column: x => x.OwnedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Header = table.Column<string>(type: "TEXT", nullable: false),
                    Body = table.Column<string>(type: "TEXT", nullable: false),
                    WrittenById = table.Column<string>(type: "TEXT", nullable: true),
                    date_posted = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Forumid = table.Column<string>(type: "TEXT", nullable: true),
                    SubForumId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_forums_Forumid",
                        column: x => x.Forumid,
                        principalTable: "forums",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Posts_SubForum_SubForumId",
                        column: x => x.SubForumId,
                        principalTable: "SubForum",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Posts_Users_WrittenById",
                        column: x => x.WrittenById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Body = table.Column<string>(type: "TEXT", nullable: false),
                    WrittenById = table.Column<string>(type: "TEXT", nullable: false),
                    PostId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comment_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comment_Users_WrittenById",
                        column: x => x.WrittenById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vote",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    VoterId = table.Column<string>(type: "TEXT", nullable: false),
                    CommentId = table.Column<string>(type: "TEXT", nullable: true),
                    PostId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vote", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vote_Comment_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comment",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Vote_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Vote_Users_VoterId",
                        column: x => x.VoterId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comment_PostId",
                table: "Comment",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_WrittenById",
                table: "Comment",
                column: "WrittenById");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_Forumid",
                table: "Posts",
                column: "Forumid");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_SubForumId",
                table: "Posts",
                column: "SubForumId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_WrittenById",
                table: "Posts",
                column: "WrittenById");

            migrationBuilder.CreateIndex(
                name: "IX_SubForum_Forumid",
                table: "SubForum",
                column: "Forumid");

            migrationBuilder.CreateIndex(
                name: "IX_SubForum_OwnedById",
                table: "SubForum",
                column: "OwnedById");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Forumid",
                table: "Users",
                column: "Forumid");

            migrationBuilder.CreateIndex(
                name: "IX_Vote_CommentId",
                table: "Vote",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_Vote_PostId",
                table: "Vote",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Vote_VoterId",
                table: "Vote",
                column: "VoterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vote");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "SubForum");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "forums");
        }
    }
}
