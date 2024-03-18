using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OrderManagement.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "supplier",
                columns: table => new
                {
                    SupplierId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    AddressLine1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AddressLine2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_supplier", x => x.SupplierId);
                });

            migrationBuilder.CreateTable(
                name: "state",
                columns: table => new
                {
                    StateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AbbAbreviaton = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    SupplierId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_state", x => x.StateId);
                    table.ForeignKey(
                        name: "FK_state_supplier_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "supplier",
                        principalColumn: "SupplierId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "supplier",
                columns: new[] { "SupplierId", "AddressLine1", "AddressLine2", "City", "Name", "PostalCode" },
                values: new object[] { new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "990 ABC XYZ, AdressLine1 ", "USA", "Seattle", "ABC_Solutions Ltd", "87474" });

            migrationBuilder.InsertData(
                table: "supplier",
                columns: new[] { "SupplierId", "AddressLine1", "AddressLine2", "City", "Name", "PostalCode" },
                values: new object[] { new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), "120 ABC XYZ, AdressLine1 ", "USA", "Portland", "XYZ_Solutions Ltd", "94992" });

            migrationBuilder.InsertData(
                table: "state",
                columns: new[] { "StateId", "AbbAbreviaton", "Name", "SupplierId" },
                values: new object[] { new Guid("80abbca8-664d-4b20-b5de-024705497d4a"), "AL", "Alabama", new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870") });

            migrationBuilder.InsertData(
                table: "state",
                columns: new[] { "StateId", "AbbAbreviaton", "Name", "SupplierId" },
                values: new object[] { new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"), "AK", "Alaska", new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870") });

            migrationBuilder.InsertData(
                table: "state",
                columns: new[] { "StateId", "AbbAbreviaton", "Name", "SupplierId" },
                values: new object[] { new Guid("86dba8c0-d185-59e7-839c-ed49555fb52a"), "AZ", "Arizona", new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3") });

            migrationBuilder.CreateIndex(
                name: "IX_state_SupplierId",
                table: "state",
                column: "SupplierId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "state");

            migrationBuilder.DropTable(
                name: "supplier");
        }
    }
}
