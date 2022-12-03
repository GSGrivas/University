using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConferenceManager.Migrations.AppDb
{
    public partial class ConferenceManager : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Topics",
                columns: table => new
                {
                    TopicId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TopicName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topics", x => x.TopicId);
                });

            migrationBuilder.CreateTable(
                name: "Papers",
                columns: table => new
                {
                    PaperId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaperTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaperAbstract = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaperAuthor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaperDateSubmitted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TopicId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Papers", x => x.PaperId);
                    table.ForeignKey(
                        name: "FK_Papers_Topics_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topics",
                        principalColumn: "TopicId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Papers_TopicId",
                table: "Papers",
                column: "TopicId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Papers");

            migrationBuilder.DropTable(
                name: "Topics");
        }
    }
}
