﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Movies.Data.Migrations
{
    public partial class EventPhotos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "Photos",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Photos_EventId",
                table: "Photos",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Events_EventId",
                table: "Photos",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Events_EventId",
                table: "Photos");

            migrationBuilder.DropIndex(
                name: "IX_Photos_EventId",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Photos");
        }
    }
}
