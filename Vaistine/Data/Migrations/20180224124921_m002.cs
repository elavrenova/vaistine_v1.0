using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Vaistine.Data.Migrations
{
    public partial class m002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DocLines_Goods_GoodId",
                table: "DocLines");

            migrationBuilder.AlterColumn<Guid>(
                name: "BaseUnitId",
                table: "Units",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<string>(
                name: "ShortDescr",
                table: "Units",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DocLines_Goods_GoodId",
                table: "DocLines",
                column: "GoodId",
                principalTable: "Goods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DocLines_Goods_GoodId",
                table: "DocLines");

            migrationBuilder.DropColumn(
                name: "ShortDescr",
                table: "Units");

            migrationBuilder.AlterColumn<Guid>(
                name: "BaseUnitId",
                table: "Units",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DocLines_Goods_GoodId",
                table: "DocLines",
                column: "GoodId",
                principalTable: "Goods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
