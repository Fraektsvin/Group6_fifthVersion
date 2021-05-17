using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DatabaseTier.Migrations
{
    public partial class UpdateIdInAddressTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomersTable_AddressTable_AddressStreetName_AddressStreet~",
                table: "CustomersTable");

            migrationBuilder.DropIndex(
                name: "IX_CustomersTable_AddressStreetName_AddressStreetNumber",
                table: "CustomersTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AddressTable",
                table: "AddressTable");

            migrationBuilder.DropColumn(
                name: "AddressStreetName",
                table: "CustomersTable");

            migrationBuilder.DropColumn(
                name: "AddressStreetNumber",
                table: "CustomersTable");

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "CustomersTable",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "StreetNumber",
                table: "AddressTable",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "StreetName",
                table: "AddressTable",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "AddressTable",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AddressTable",
                table: "AddressTable",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_CustomersTable_AddressId",
                table: "CustomersTable",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomersTable_AddressTable_AddressId",
                table: "CustomersTable",
                column: "AddressId",
                principalTable: "AddressTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomersTable_AddressTable_AddressId",
                table: "CustomersTable");

            migrationBuilder.DropIndex(
                name: "IX_CustomersTable_AddressId",
                table: "CustomersTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AddressTable",
                table: "AddressTable");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "CustomersTable");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "AddressTable");

            migrationBuilder.AddColumn<string>(
                name: "AddressStreetName",
                table: "CustomersTable",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddressStreetNumber",
                table: "CustomersTable",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "StreetNumber",
                table: "AddressTable",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "StreetName",
                table: "AddressTable",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AddressTable",
                table: "AddressTable",
                columns: new[] { "StreetName", "StreetNumber" });

            migrationBuilder.CreateIndex(
                name: "IX_CustomersTable_AddressStreetName_AddressStreetNumber",
                table: "CustomersTable",
                columns: new[] { "AddressStreetName", "AddressStreetNumber" });

            migrationBuilder.AddForeignKey(
                name: "FK_CustomersTable_AddressTable_AddressStreetName_AddressStreet~",
                table: "CustomersTable",
                columns: new[] { "AddressStreetName", "AddressStreetNumber" },
                principalTable: "AddressTable",
                principalColumns: new[] { "StreetName", "StreetNumber" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}
