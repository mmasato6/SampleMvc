﻿using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SampleCFModelMVC.Data.Migrations
{
    public partial class ChangePerson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PrefectureId",
                table: "Person",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Prefecture",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prefecture", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Person_PrefectureId",
                table: "Person",
                column: "PrefectureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Prefecture_PrefectureId",
                table: "Person",
                column: "PrefectureId",
                principalTable: "Prefecture",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_Prefecture_PrefectureId",
                table: "Person");

            migrationBuilder.DropTable(
                name: "Prefecture");

            migrationBuilder.DropIndex(
                name: "IX_Person_PrefectureId",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "PrefectureId",
                table: "Person");
        }
    }
}
