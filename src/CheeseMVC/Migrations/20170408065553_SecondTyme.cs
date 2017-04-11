using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CheeseMVC.Migrations
{
    public partial class SecondTyme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Cheeses");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Cheeses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Cheeses_CategoryId",
                table: "Cheeses",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cheeses_Categories_CategoryId",
                table: "Cheeses",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cheeses_Categories_CategoryId",
                table: "Cheeses");

            migrationBuilder.DropIndex(
                name: "IX_Cheeses_CategoryId",
                table: "Cheeses");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Cheeses");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Cheeses",
                nullable: false,
                defaultValue: 0);
        }
    }
}
