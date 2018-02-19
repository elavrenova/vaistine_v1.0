using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Vaistine.Data.Migrations
{
    public partial class m001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Docs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Descr = table.Column<string>(nullable: true),
                    FromCagId = table.Column<Guid>(nullable: false),
                    FromDate = table.Column<DateTime>(nullable: false),
                    FromStoreId = table.Column<Guid>(nullable: false),
                    ToCagId = table.Column<Guid>(nullable: false),
                    ToDate = table.Column<DateTime>(nullable: false),
                    ToStoreId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Docs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Docs_Cags_FromCagId",
                        column: x => x.FromCagId,
                        principalTable: "Cags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Docs_Stores_FromStoreId",
                        column: x => x.FromStoreId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Docs_Cags_ToCagId",
                        column: x => x.ToCagId,
                        principalTable: "Cags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Docs_Stores_ToStoreId",
                        column: x => x.ToStoreId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DocLines",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DocHeadId = table.Column<Guid>(nullable: false),
                    GoodId = table.Column<Guid>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Quantity = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocLines_Docs_DocHeadId",
                        column: x => x.DocHeadId,
                        principalTable: "Docs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DocLines_Goods_GoodId",
                        column: x => x.GoodId,
                        principalTable: "Goods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DocLines_DocHeadId",
                table: "DocLines",
                column: "DocHeadId");

            migrationBuilder.CreateIndex(
                name: "IX_DocLines_GoodId",
                table: "DocLines",
                column: "GoodId");

            migrationBuilder.CreateIndex(
                name: "IX_Docs_FromCagId",
                table: "Docs",
                column: "FromCagId");

            migrationBuilder.CreateIndex(
                name: "IX_Docs_FromStoreId",
                table: "Docs",
                column: "FromStoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Docs_ToCagId",
                table: "Docs",
                column: "ToCagId");

            migrationBuilder.CreateIndex(
                name: "IX_Docs_ToStoreId",
                table: "Docs",
                column: "ToStoreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DocLines");

            migrationBuilder.DropTable(
                name: "Docs");
        }
    }
}
