using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OrderManagement.Migrations
{
    public partial class UpdateTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_state_supplier_SupplierId",
                table: "state");

            migrationBuilder.DropIndex(
                name: "IX_state_SupplierId",
                table: "state");

            migrationBuilder.DeleteData(
                table: "state",
                keyColumn: "StateId",
                keyValue: new Guid("80abbca8-664d-4b20-b5de-024705497d4a"));

            migrationBuilder.DeleteData(
                table: "state",
                keyColumn: "StateId",
                keyValue: new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"));

            migrationBuilder.DeleteData(
                table: "state",
                keyColumn: "StateId",
                keyValue: new Guid("86dba8c0-d185-59e7-839c-ed49555fb52a"));

            migrationBuilder.DeleteData(
                table: "supplier",
                keyColumn: "SupplierId",
                keyValue: new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"));

            migrationBuilder.DeleteData(
                table: "supplier",
                keyColumn: "SupplierId",
                keyValue: new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"));

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "state");

            migrationBuilder.AddColumn<Guid>(
                name: "StateId",
                table: "supplier",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "state",
                columns: new[] { "StateId", "AbbAbreviaton", "Name" },
                values: new object[,]
                {
                    { new Guid("739561c4-8ba5-4b56-aa11-9891882668f6"), "AL", "Alabama" },
                    { new Guid("1fbdc0fa-d3cb-47b0-86f8-bb11a46cbfba"), "AK", "Alaska" },
                    { new Guid("2d715fc3-1687-4723-a3d6-bb1e2b9fcb37"), "AZ", "Arizona" },
                    { new Guid("13c1d98a-9420-4b20-ad16-105d73b9dd69"), "AR", "Arkansas" },
                    { new Guid("32331d91-5b4e-4b20-8ea4-14062bcf1517"), "CA", "California" },
                    { new Guid("9a4aa09b-ce6e-4cc5-82dc-6928e4645df7"), "CO", "Colorado" }
                });

            migrationBuilder.InsertData(
                table: "supplier",
                columns: new[] { "SupplierId", "AddressLine1", "AddressLine2", "City", "Name", "PostalCode", "StateId" },
                values: new object[,]
                {
                    { new Guid("391f8f7d-5f1d-46e1-bcfd-1148422342b1"), "990 ABC XYZ, AdressLine1 ", "USA", "Huntsville", "ABC_Solutions Ltd", "87474", new Guid("739561c4-8ba5-4b56-aa11-9891882668f6") },
                    { new Guid("87e1244c-01f6-45f5-a080-2bab9e0319bb"), "120 ABC XYZ, AdressLine1 ", "USA", "Little Rock", "New_Solutions Ltd", "80014", new Guid("13c1d98a-9420-4b20-ad16-105d73b9dd69") },
                    { new Guid("679c685e-2e9c-4c01-a786-d19e7fd10b48"), "120 ABC XYZ, AdressLine1 ", "USA", "Los Angeles", "XYZ_Solutions Ltd", "94992", new Guid("32331d91-5b4e-4b20-8ea4-14062bcf1517") },
                    { new Guid("b4d1f629-0218-4629-9648-aa11451e64e3"), "120 ABC XYZ, AdressLine1 ", "USA", "Denver", "GHJ_Solutions Ltd", "80014", new Guid("9a4aa09b-ce6e-4cc5-82dc-6928e4645df7") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_supplier_StateId",
                table: "supplier",
                column: "StateId");

            migrationBuilder.AddForeignKey(
                name: "FK_supplier_state_StateId",
                table: "supplier",
                column: "StateId",
                principalTable: "state",
                principalColumn: "StateId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_supplier_state_StateId",
                table: "supplier");

            migrationBuilder.DropIndex(
                name: "IX_supplier_StateId",
                table: "supplier");

            migrationBuilder.DeleteData(
                table: "state",
                keyColumn: "StateId",
                keyValue: new Guid("1fbdc0fa-d3cb-47b0-86f8-bb11a46cbfba"));

            migrationBuilder.DeleteData(
                table: "state",
                keyColumn: "StateId",
                keyValue: new Guid("2d715fc3-1687-4723-a3d6-bb1e2b9fcb37"));

            migrationBuilder.DeleteData(
                table: "supplier",
                keyColumn: "SupplierId",
                keyValue: new Guid("391f8f7d-5f1d-46e1-bcfd-1148422342b1"));

            migrationBuilder.DeleteData(
                table: "supplier",
                keyColumn: "SupplierId",
                keyValue: new Guid("679c685e-2e9c-4c01-a786-d19e7fd10b48"));

            migrationBuilder.DeleteData(
                table: "supplier",
                keyColumn: "SupplierId",
                keyValue: new Guid("87e1244c-01f6-45f5-a080-2bab9e0319bb"));

            migrationBuilder.DeleteData(
                table: "supplier",
                keyColumn: "SupplierId",
                keyValue: new Guid("b4d1f629-0218-4629-9648-aa11451e64e3"));

            migrationBuilder.DeleteData(
                table: "state",
                keyColumn: "StateId",
                keyValue: new Guid("13c1d98a-9420-4b20-ad16-105d73b9dd69"));

            migrationBuilder.DeleteData(
                table: "state",
                keyColumn: "StateId",
                keyValue: new Guid("32331d91-5b4e-4b20-8ea4-14062bcf1517"));

            migrationBuilder.DeleteData(
                table: "state",
                keyColumn: "StateId",
                keyValue: new Guid("739561c4-8ba5-4b56-aa11-9891882668f6"));

            migrationBuilder.DeleteData(
                table: "state",
                keyColumn: "StateId",
                keyValue: new Guid("9a4aa09b-ce6e-4cc5-82dc-6928e4645df7"));

            migrationBuilder.DropColumn(
                name: "StateId",
                table: "supplier");

            migrationBuilder.AddColumn<Guid>(
                name: "SupplierId",
                table: "state",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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

            migrationBuilder.AddForeignKey(
                name: "FK_state_supplier_SupplierId",
                table: "state",
                column: "SupplierId",
                principalTable: "supplier",
                principalColumn: "SupplierId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
